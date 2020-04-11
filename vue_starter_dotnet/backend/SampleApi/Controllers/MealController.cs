using System;
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
        public IActionResult AddMeal([FromBody] Meal meal)
        {
            meal.UserName = User.Identity.Name;
            mealDao.AddMeal(meal);

            return Ok();
        }

        [HttpGet("foodSearch/{foodSearch}")]
        public async Task<ActionResult> FoodSearch([FromRoute] string foodSearch)
        {
            List<Meal> meals = new List<Meal>();
            
            using (var client = new HttpClient())
            {
                var apiKey = "GQVsihhcGgBndgYOHrE6Ny0CDsaNxX5Iiy4pfbAc";
                client.BaseAddress = new Uri($"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={apiKey}&query={foodSearch}");

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
                        Meal meal = new Meal();
                        meal.FDCID = root.foods[i].fdcId;
                        meal.FoodName = root.foods[i].description;
                        for (int j = 0; j < root.foods[i].foodNutrients.Length; j++)
                        {
                            if (root.foods[i].foodNutrients[j].nutrientName == "Energy")
                            {
                                meal.TotalCalories = Convert.ToInt32(root.foods[i].foodNutrients[j].nutrientNumber);
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