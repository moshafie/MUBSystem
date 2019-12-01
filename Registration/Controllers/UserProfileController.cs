using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Models;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private UserManager<ApplicationUser> _ApplicationUser;
        private AuthenticationContext _context;
        public UserProfileController(UserManager<ApplicationUser> userManager, AuthenticationContext context)
        {
            _ApplicationUser = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        //Get : /api/UserProfile
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _ApplicationUser.FindByIdAsync(userId);
         
            return new
            {
                user.UserName,
                user.Email,
                user.fullName,
            };

            }
        

    }
}