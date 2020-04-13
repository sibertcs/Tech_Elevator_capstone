using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Meal
    {
        public int MealID { get; set; }
        public int FDCID { get; set; }
        public string FoodName { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public decimal Servings { get; set; }
        public string MealType { get; set; }
        public int FoodCalories { get; set; }
        public int TotalCalories { get; set; }
        public string UserName { get; set; }
        

    }
}
