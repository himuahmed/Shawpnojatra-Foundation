using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shawpnojatra_Foundation.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shawpnojatra_Foundation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        public AccountController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/account/createuser")]
        public async Task<IActionResult> CreateUser(string username,string password)
        {
            if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var result = await _authenticationService.CreateUser(username, password);
                if (result.Succeeded)
                {
                    return Ok("User Created.");
                }
                else
                {
                    return BadRequest("Failed to create user.");
                }
            }
            else
            {
                return BadRequest("Failed to create user.");
            }
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/account/signin")]

        public async Task<IActionResult> SignIn(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Failed to login.");
            }
            var user = await _authenticationService.SignIn(username, password);
            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AuthSetting:tokenKey").Value));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

    }
}
