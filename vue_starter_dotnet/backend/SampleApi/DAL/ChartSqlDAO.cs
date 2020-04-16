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

        public List<int> GetDataForWeek(string userName)
        {
            List<int> model = new List<int>();

            
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
                    int data;
                    try
                    {
                        while (reader.Read())
                        {
                                
                            data = Convert.ToInt32(reader["sum"]);
                            model.Add(data);
                        }
                    }
                    catch
                    {
                        data = 0;
                        model.Add(data);
                        continue;
                    }
                        

                }

            }
                 
            return model;
        }

        public List<int> GetDataForMonth(string userName)
        {
            List<int> model = new List<int>();

            int trackerOne = 0;
            int trackerTwo = -6;

            for (int i = 0; i < 4; i++)
            {
                
                DateTime date = DateTime.Now.AddDays(trackerOne);
                string dateTrimmed = date.ToString("yyyy-MM-dd");

                DateTime sevenDaysAgo = DateTime.Now.AddDays(trackerTwo);
                string sevenDaysAgoTrimmed = sevenDaysAgo.ToString("yyyy-MM-dd");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT sum(total_calories) AS sum FROM meals WHERE user_name = @userName AND consumption_date <= @dateTrimmed AND consumption_date >= @sevenDaysAgoTrimmed", conn);
                    cmd.Parameters.AddWithValue("@dateTrimmed", dateTrimmed);
                    cmd.Parameters.AddWithValue("@sevenDaysAgoTrimmed", sevenDaysAgoTrimmed);
                    cmd.Parameters.AddWithValue("@userName", userName);


                    SqlDataReader reader = cmd.ExecuteReader();
                    int data;
                    try
                    {
                        while (reader.Read())
                        {
                            data = Convert.ToInt32(reader["sum"]);
                            model.Add(data);
                            trackerOne -= 7;
                            trackerTwo -= 7;

                        }
                    }
                    catch
                    {
                        data = 0;
                        model.Add(data);
                        trackerOne -= 6;
                        trackerTwo -= 6;
                        continue;
                        
                    }
                    

                }
                

            }

            return model;
        }

        public List<int> GetDataForYear(string userName)
        {
            List<int> model = new List<int>();

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
                    int data;
                    try
                    {
                        while (reader.Read())
                        {
                            data = Convert.ToInt32(reader["sum"]);
                            model.Add(data);
                        }
                    }
                    catch
                    {
                        data = 0;
                        model.Add(data);
                        currentMonth--;
                        if (currentMonth == 0)
                        {
                            currentMonth = 12;
                            currentYear--;
                        }
                        continue;
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
