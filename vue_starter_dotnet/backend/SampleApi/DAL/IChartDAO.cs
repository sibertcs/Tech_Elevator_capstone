using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IChartDAO
    {
        ChartModel GetDataForWeek(string userName);

        ChartModel GetDataForMonth(string userName);

        ChartModel GetDataForYear(string userName);

        List<DailyChartModel> GetDataForDay(string userName, DateTime filterDate);

    }
}
