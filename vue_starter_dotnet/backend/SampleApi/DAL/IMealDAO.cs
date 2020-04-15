using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IMealDAO
    {
        void AddMeal(MealModel meal);
        
        void RemoveEntry(int mealId);

        void EditEntry(MealModel meal);

        List<MealModel> DisplayEntries(string userName);

        List<MealModel> GetChartData(string userName, DateTime date);
    }
}
