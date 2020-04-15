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
    public class ChartController : Controller
    {
        private IChartDAO chartDao;

        public ChartController(IChartDAO dao)
        {
            this.chartDao = dao;
        }

        [HttpGet("getDataForWeek")]
        public IActionResult GetDataForWeek()
        {
            string username = User.Identity.Name;
            ChartModel model = chartDao.GetDataForWeek(username);
            return Ok(model);
        }

        [HttpGet("getDataForMonth")]
        public IActionResult GetDataForMonth()
        {
            string username = User.Identity.Name;
            ChartModel model = chartDao.GetDataForMonth(username);
            return Ok(model);
        }

        [HttpGet("getDataForYear")]
        public IActionResult GetDataForYear()
        {
            string username = User.Identity.Name;
            ChartModel model = chartDao.GetDataForYear(username);
            return Ok(model);
        }
        [HttpGet("getDataForDay/{filterDate}")]
        public IActionResult GetDataForDay([FromRoute] DateTime filterDate)
        {
            string username = User.Identity.Name;
            List<DailyChartModel> model = chartDao.GetDataForDay(username, filterDate);
            return Ok(model);
        }
        [HttpGet("getCurrentDate")]
        public IActionResult GetCurrentDate()
        {
            DateTime date = new DateTime();





















































































            string trimmedDate= date.Year + "-" + date.Month + "-" + date.Day;
            return Ok(trimmedDate);
        }
    }
}