using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Registration.Models;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _UserManager;
        private SignInManager<ApplicationUser> _SignInManager;
        private readonly ApplicationSetting _applicationSetting;

        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSetting> applicationSetting)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _applicationSetting = applicationSetting.Value;
        }

        [HttpPost("register")]        
        public async Task<IActionResult> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                fullName = model.FullName,
                
            };
            try
            {
                var result = await _UserManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        [HttpPost()]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _UserManager.FindByNameAsync(model.UserName);
            if (user != null && await _UserManager.CheckPasswordAsync(user, model.Password))
            {
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity
                   (new Claim[]
                      { new Claim("UserId", user.Id.ToString())

                      }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSetting.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(TokenDescriptor);
                var Token = tokenHandler.WriteToken(securityToken);
                return Ok(new { Token });
            }
            else return BadRequest(new { message = "UserName Or Password is not correct" });
        } 




    }
} 