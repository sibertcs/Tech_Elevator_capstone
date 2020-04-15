using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for profile data objects.
    /// </summary>
    public interface IProfileDAO
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        void AddProfile(ProfileModel profile);
        void EditProfile(ProfileModel profile);

        ProfileModel GetProfile(string userName);
    }
}
