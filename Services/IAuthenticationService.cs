using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Shawpnojatra_Foundation.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateUser(string username, string password);
        Task<IdentityUser> SignIn(string username, string password);
        Task<bool> UserExists(string username);
    }
}