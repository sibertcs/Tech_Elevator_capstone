using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class MealSqlDAO : IMealDAO
    {

        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public MealSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void AddMeal(Meal meal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO meals VALUES (@mealId, @foodName, @consumptionDate, @servings, @mealType, @totalCalories, @userName);", conn);
                    cmd.Parameters.AddWithValue("@mealId", meal.FDCID);
                    cmd.Parameters.AddWithValue("@foodName", meal.FoodName);
                    cmd.Parameters.AddWithValue("@consumptionDate", meal.ConsumptionDate);
                    cmd.Parameters.AddWithValue("@servings", meal.Servings);
                    cmd.Parameters.AddWithValue("@mealType", meal.MealType);
                    cmd.Parameters.AddWithValue("@totalCalories", meal.TotalCalories);
                    cmd.Parameters.AddWithValue("@userName", meal.UserName);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}
