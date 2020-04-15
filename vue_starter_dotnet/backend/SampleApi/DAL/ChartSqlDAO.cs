using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class ChartSqlDAO : IChartDAO
    {

        private readonly string connectionString;

        public ChartSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ChartModel GetDataForWeek(string userName)
        {
            ChartModel model = new ChartModel();

            for (int i = 0; i < 7; i++)
            {
                DateTime date = DateTime.Now.AddDays(-i);
                string dateTrimmed = date.ToString("yyyy-MM-dd");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sum(total_calories) AS sum FROM meals WHERE user_name = @userName AND consumption_date = @dateTrimmed", conn);
                    cmd.Parameters.AddWithValue("@dateTrimmed", dateTrimmed);
                    cmd.Parameters.AddWithValue("@userName", userName);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.TotalCaloriesPerPeriod.Add(Convert.ToInt32(reader["sum"]));
                    }

                }

            }
            return model;
        }

        public ChartModel GetDataForMonth(string userName)
        {
            ChartModel model = new ChartModel();

            for (int i = 0; i < 4; i++)
            {
                int trackerOne = 0;
                int trackerTwo = -6;

                DateTime date = DateTime.Now.AddDays(trackerOne);
                string dateTrimmed = date.ToString("yyyy-MM-dd");

                DateTime sevenDaysAgo = DateTime.Now.AddDays(trackerTwo);
                string sevenDaysAgoTrimmed = sevenDaysAgo.ToString("yyyy-MM-dd");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sum(total_calories) AS sum FROM meals WHERE user_name = @userName AND consumption_date BETWEEN @dateTrimmed AND @sevenDaysAgoTrimmed", conn);
                    cmd.Parameters.AddWithValue("@dateTrimmed", dateTrimmed);
                    cmd.Parameters.AddWithValue("@sevenDaysAgoTrimmed", sevenDaysAgoTrimmed);
                    cmd.Parameters.AddWithValue("@userName", userName);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.TotalCaloriesPerPeriod.Add(Convert.ToInt32(reader["sum"]));
                    }

                }
                trackerOne -= 6;
                trackerTwo -= 6;

            }

            return model;
        }

        public ChartModel GetDataForYear(string userName)
        {
            ChartModel model = new ChartModel();

            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;

            for (int i = 0; i < 12; i++)
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sum(total_calories) AS sum FROM meals WHERE user_name = @userName AND YEAR(consumption_date) = @currentYear AND MONTH(consumption_date) = @currentMonth", conn);
                    cmd.Parameters.AddWithValue("@currentMonth", currentMonth);
                    cmd.Parameters.AddWithValue("@currentYear", currentYear);
                    cmd.Parameters.AddWithValue("@userName", userName);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.TotalCaloriesPerPeriod.Add(Convert.ToInt32(reader["sum"]));
                    }

                }
                currentMonth--;
                if (currentMonth == 0)
                {
                    currentMonth = 12;
                    currentYear--;
                }

            }
            return model;
        }

        public List<DailyChartModel> GetDataForDay(string userName, DateTime filterDate)
        {
            List<DailyChartModel> model = new List<DailyChartModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT meal_type, total_calories FROM meals WHERE user_name = @userName AND consumption_date = @filterDate", conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@filterDate", filterDate);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DailyChartModel day = new DailyChartModel();
                    day.TotalCalories = Convert.ToInt32(reader["total_calories"]);
                    day.MealType = Convert.ToString(reader["meal_type"]);
                    model.Add(day);
                }
            }

            return model;
        }


    }
}
