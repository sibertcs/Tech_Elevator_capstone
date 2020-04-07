using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a user's profile in the system.
    /// </summary>
    public class Profile
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
        public string Picture { get; set; }
        /// <summary>
        /// Represents a user in the system.
        /// </summary>

        public string UserName { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    }

}
