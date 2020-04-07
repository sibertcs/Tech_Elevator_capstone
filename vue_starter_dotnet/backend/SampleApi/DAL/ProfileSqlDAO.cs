using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class ProfileSqlDAO : IProfileDAO
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
        public void AddProfile(Profile profile)
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
                    cmd.Parameters.AddWithValue("@picture", profile.Picture);
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

    }
}
