using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

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
    }
}