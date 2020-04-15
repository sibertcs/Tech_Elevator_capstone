using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{

    public class ProfileModel
    {
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public int CurrentWeight { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public int GoalWeight { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public string ProfilePicture { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>
        public string DisplayName { get; set; }
        public string UserName { get; set; }



    }

}
