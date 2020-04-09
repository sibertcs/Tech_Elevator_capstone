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

        [HttpPut("editProfile")]
        public IActionResult EditProfile([FromBody] Profile profile)
        {
            profile.UserName = User.Identity.Name;
            profileDao.EditProfile(profile);

            return Ok();
        }
        [HttpGet ("GetProfile")]
        public IActionResult GetProfile()
        {
            string userName = User.Identity.Name;

            var result = profileDao.GetProfile(userName);
            result.BirthDate = result.BirthDate.Date;

            return Ok(result);
        }
        private static DateTime TrimDate(DateTime date)
        {
            return new DateTime(
                date.Year,
                date.Month,
                date.Day
                );
        }

    }

}
