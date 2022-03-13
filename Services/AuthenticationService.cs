using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shawpnojatra_Foundation.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userMgr;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthenticationService(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInManager)
        {
             _userMgr = userMgr;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUser(string username, string password)
        {
            var newUser = new IdentityUser()
            {
                Email = username,
                UserName = username
            };
            IdentityResult res =  await _userMgr.CreateAsync(newUser, password);
            return res;
        }

        public async Task<IdentityUser> SignIn(string username, string password)
        {
            var user = await _userMgr.Users.FirstOrDefaultAsync(x => x.UserName == username) ?? await _userMgr.Users.FirstOrDefaultAsync(x => x.Email == username);
            if (user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(username ,password, false, false);
            
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _userMgr.Users.AnyAsync(u => u.UserName == username))
                return true;

            return false;
        }
    }
}
