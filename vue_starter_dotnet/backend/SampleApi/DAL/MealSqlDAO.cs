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
                    SqlCommand cmd = new SqlCommand("INSERT INTO meals VALUES (@mealId, @foodName, @consumptionDate, @servings, @mealType, @foodCalories, @totalCalories, @userName);", conn);
                    cmd.Parameters.AddWithValue("@mealId", meal.FDCID);
                    cmd.Parameters.AddWithValue("@foodName", meal.FoodName);
                    cmd.Parameters.AddWithValue("@consumptionDate", meal.ConsumptionDate);
                    cmd.Parameters.AddWithValue("@servings", meal.Servings);
                    cmd.Parameters.AddWithValue("@mealType", meal.MealType);
                    cmd.Parameters.AddWithValue("@foodCalories", meal.FoodCalories);
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
        

        public void RemoveEntry(int mealId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM meals WHERE @mealId = meal_id", conn);
                cmd.Parameters.AddWithValue("@mealId", mealId);

                cmd.ExecuteNonQuery();

            }
        }

        public void EditEntry(Meal meal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE meals SET servings = @servings, meal_type = @mealType, total_calories = @totalCalories WHERE meal_id = @mealID;", conn);
                    cmd.Parameters.AddWithValue("@servings", meal.Servings);
                    cmd.Parameters.AddWithValue("@mealType", meal.MealType);
                    cmd.Parameters.AddWithValue("@mealID", meal.MealID);
                    cmd.Parameters.AddWithValue("@totalCalories", meal.TotalCalories);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<Meal> DisplayEntries(string userName)
        {
            List<Meal> meals = new List<Meal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT fdc_id, meal_id, food_name, consumption_date, servings, meal_type, food_calories, total_calories FROM meals WHERE user_name = @userName", conn);
                cmd.Parameters.AddWithValue("@userName", userName);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Meal meal = new Meal();
                    meal.FDCID = Convert.ToInt32(reader["fdc_id"]);
                    meal.MealID = Convert.ToInt32(reader["meal_id"]);
                    meal.FoodName = Convert.ToString(reader["food_name"]);
                    meal.ConsumptionDate = Convert.ToDateTime(reader["consumption_date"]);
                    meal.Servings = Convert.ToDecimal(reader["servings"]);
                    meal.MealType = Convert.ToString(reader["meal_type"]);
                    meal.FoodCalories = Convert.ToInt32(reader["food_calories"]);
                    meal.TotalCalories = Convert.ToInt32(reader["total_calories"]);
                    meals.Add(meal);
                }
            }
            return meals;
        }
        public List<Meal> GetChartData(string userName, DateTime filterDate)
        {
            List<Meal> meals = new List<Meal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT fdc_id, meal_id, food_name, consumption_date, servings, meal_type, food_calories, total_calories FROM meals WHERE user_name = @userName AND consumption_date = @filterDate", conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@filterDate", filterDate);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Meal meal = new Meal();
                    meal.FDCID = Convert.ToInt32(reader["fdc_id"]);
                    meal.MealID = Convert.ToInt32(reader["meal_id"]);
                    meal.FoodName = Convert.ToString(reader["food_name"]);
                    meal.ConsumptionDate = Convert.ToDateTime(reader["consumption_date"]);
                    meal.Servings = Convert.ToDecimal(reader["servings"]);
                    meal.MealType = Convert.ToString(reader["meal_type"]);
                    meal.FoodCalories = Convert.ToInt32(reader["food_calories"]);
                    meal.TotalCalories = Convert.ToInt32(reader["total_calories"]);
                    meals.Add(meal);
                }
            }
            return meals;
        }




    }
}
