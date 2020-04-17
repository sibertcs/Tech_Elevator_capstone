using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class ProfileSqlDAO : IProfileDAO

    {

        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public ProfileSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void AddProfile(ProfileModel profile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO profiles VALUES (@birthDate, @currentWeight, @goalWeight, @height, @picture, @userName);", conn);
                    cmd.Parameters.AddWithValue("@birthDate", profile.BirthDate);
                    cmd.Parameters.AddWithValue("@currentWeight", profile.CurrentWeight);
                    cmd.Parameters.AddWithValue("@goalWeight", profile.GoalWeight);
                    cmd.Parameters.AddWithValue("@height", profile.Height);
                    cmd.Parameters.AddWithValue("@picture", profile.ProfilePicture);
                    cmd.Parameters.AddWithValue("@userName", profile.UserName);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void EditProfile(ProfileModel profile)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE profiles SET birth_date = @birthDate, current_weight = @currentWeight, goal_weight = @goalWeight, height = @height, profile_picture = @picture, display_name = @displayName, user_name = @userName WHERE user_name = @userName;", conn);
                    cmd.Parameters.AddWithValue("@birthDate", profile.BirthDate);
                    cmd.Parameters.AddWithValue("@currentWeight", profile.CurrentWeight);
                    cmd.Parameters.AddWithValue("@goalWeight", profile.GoalWeight);
                    cmd.Parameters.AddWithValue("@height", profile.Height);
                    cmd.Parameters.AddWithValue("@picture", profile.ProfilePicture);
                    cmd.Parameters.AddWithValue("@displayName", profile.DisplayName);
                    cmd.Parameters.AddWithValue("@userName", profile.UserName);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public ProfileModel GetProfile(string userName)
        {
            ProfileModel profile = new ProfileModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM profiles WHERE user_name = @userName", conn);
                cmd.Parameters.AddWithValue("@userName", userName);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    profile.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                    profile.Height = Convert.ToInt32(reader["height"]);
                    profile.CurrentWeight = Convert.ToInt32(reader["current_weight"]);
                    profile.GoalWeight = Convert.ToInt32(reader["goal_weight"]);
                    profile.ProfilePicture = Convert.ToString(reader["profile_picture"]);
                    profile.DisplayName = Convert.ToString(reader["display_name"]);
                    profile.UserName = Convert.ToString(reader["user_name"]);
                }
            }
            return profile;
        }
        
    }
}
