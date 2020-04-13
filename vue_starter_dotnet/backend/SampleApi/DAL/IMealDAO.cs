using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IMealDAO
    {
        void AddMeal(Meal meal);

        List<Meal> DisplayEntries(string userName);

        void RemoveEntry(int mealId);

        void EditEntry(Meal meal);
    }
}
