using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<User> Login(string Username, string Password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] passwordHash , PasswordSalt;
            CreatePasswordHash(Password,out passwordHash, out PasswordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = PasswordSalt;

            await  _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public Task<bool> UserExist(string Username)
        {
            throw new System.NotImplementedException();
        }
    }
}