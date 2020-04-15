using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class DailyChartModel
    {
        public List<string> MealType { get; set; }

        public List<int> TotalCalories { get; set; }
    }
}
