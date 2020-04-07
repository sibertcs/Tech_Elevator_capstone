using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ProfileController : Controller
    {
        private IProfileDAO profileDao;

        public ProfileController(IProfileDAO dao)
        {
            this.profileDao = dao;
        }


        /// <summary>
        /// Authenticates the user and provides a bearer token.
        /// </summary>
        /// <param name="profile">An object including the user's credentials.</param> 
        /// <returns></returns>
        [HttpPost("addProfile")]
        public IActionResult AddProfile([FromBody] Profile profile)
        {
            profile.UserName = User.Identity.Name;
            profileDao.AddProfile(profile);

            return Ok();


        }
    
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
