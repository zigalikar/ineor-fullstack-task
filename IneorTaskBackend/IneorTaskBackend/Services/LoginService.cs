using System;
using System.Linq;
using System.Threading.Tasks;
using IneorTaskBackend.Context;
using IneorTaskBackend.Helpers;
using IneorTaskBackend.Interfaces;
using IneorTaskBackend.Model.Login;
using Microsoft.EntityFrameworkCore;

namespace IneorTaskBackend.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _dbContext;

        public LoginService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = _dbContext.Users.SingleOrDefault((user) => user.Username.Equals(loginRequest.Username));
            if (user == null)
                return null;

            var passwordHash = TokenHelper.Hash(loginRequest.Password, Convert.FromBase64String(user.PasswordSalt));
            if (!user.Password.Equals(passwordHash))
                return null;

            var token = await Task.Run(() => TokenHelper.GenerateAccessToken(user));
            return new LoginResponse { AccessToken = token };
        }

        public async Task SignupAsync(LoginRequest signupRequest)
        {
            var existingUser = await _dbContext.Users.SingleOrDefaultAsync(user => user.Username.Equals(signupRequest.Username));
            if (existingUser != null)
                return;

            var salt = TokenHelper.GetSecureSalt();
            var passwordHash = TokenHelper.Hash(signupRequest.Password, salt);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = signupRequest.Username,
                Password = passwordHash,
                PasswordSalt = Convert.ToBase64String(salt)
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

