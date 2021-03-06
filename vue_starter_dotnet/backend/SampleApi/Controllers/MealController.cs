﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApi.DAL;
using SampleApi.Models;
using static SampleApi.Models.APIModel;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private IMealDAO mealDao;

        public MealController(IMealDAO dao)
        {
            this.mealDao = dao;
        }

        /// <summary>
        /// Authenticates the user and provides a bearer token.
        /// </summary>
        /// <param name="meal">An object including the user's credentials.</param> 
        /// <returns></returns>
        [HttpPost("addMeal")]
        public IActionResult AddMeal([FromBody] MealModel meal)
        {
            meal.UserName = User.Identity.Name;
            mealDao.AddMeal(meal);

            return Ok();
        }
        [HttpGet("displayEntries")]
        public IActionResult DisplayEntries()
        {
            string userName = User.Identity.Name;
            List<MealModel> meals = mealDao.DisplayEntries(userName);
            return Ok(meals);
        }
        [HttpGet("getChartData/{filterDate}")]
        public IActionResult GetChartData([FromRoute] DateTime filterDate)
        {
            //DateTime filterDate = Convert.ToDateTime(date);
            string userName = User.Identity.Name;
            List<MealModel> meals = mealDao.GetChartData(userName, filterDate);
            return Ok(meals);
        }


        [HttpDelete("removeEntry")]
        public IActionResult RemoveEntry([FromBody] int mealId)
        {
            mealDao.RemoveEntry(mealId);
            return Ok();
        }

        [HttpPut("editEntry")]
        public IActionResult EditEntry([FromBody] MealModel meal)
        {
            mealDao.EditEntry(meal);
            return Ok();
        }
            
        [HttpGet("foodSearch/{foodSearch}")]
        public async Task<ActionResult> FoodSearch([FromRoute] string foodSearch)
        {
            List<MealModel> meals = new List<MealModel>();
            
            using (var client = new HttpClient())
            {
                var apiKey = "GQVsihhcGgBndgYOHrE6Ny0CDsaNxX5Iiy4pfbAc";
                client.BaseAddress = new Uri($"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={apiKey}&query={foodSearch}&pageSize=50");
               
                //HTTP GET
                //var responseTask = client.GetAsync("&query=" + foodSearch);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<RootObject>(content);
                    for (int i = 0; i < root.foods.Length; i++)
                    {
                        MealModel meal = new MealModel();
                        meal.FDCID = root.foods[i].fdcId;
                        meal.FoodName = root.foods[i].description;
                        meal.Servings = 1;
                        meal.MealType = "Breakfast";
                        meal.ConsumptionDate = DateTime.Now;
                        for (int j = 0; j < root.foods[i].foodNutrients.Length; j++)
                        {
                            if (root.foods[i].foodNutrients[j].nutrientName == "Energy")
                            {
                                meal.FoodCalories = Convert.ToInt32(root.foods[i].foodNutrients[j].value);
                            }
                        }

                        meals.Add(meal);
                    }
                }
            }

            return Ok(meals);
        }
    }
}