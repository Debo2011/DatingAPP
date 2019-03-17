using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
        // Register Method
         Task<User> Register (User user,string Password);

        // Login Method
         Task<User> Login (string Username , string Password);

        // UserExist Method
         Task<bool> UserExist (string Username);
    }
}