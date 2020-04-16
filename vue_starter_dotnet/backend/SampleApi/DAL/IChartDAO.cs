using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IChartDAO
    {
        List<int> GetDataForWeek(string userName);

        List<int> GetDataForMonth(string userName);

        List<int> GetDataForYear(string userName);

        List<DailyChartModel> GetDataForDay(string userName, DateTime filterDate);

    }
}
