using IneorTaskBackend.Helpers;
using IneorTaskBackend.Interfaces;
using IneorTaskBackend.Model.Login;

namespace IneorTaskBackend.Tests.Services
{
    public class LoginServiceFake : ILoginService
    {
        public List<User> Users = new ()
        {
            new User
            {
                Id = "03ff811d-7873-4ea7-934e-d391042a73fe",
                Username = "admin",
                Password = "t+10+QkbwtG+XAjF5NC5YvlW7D2S4pEZ55+/wP72q4g=", // admin
                PasswordSalt = "zgTSXVdN6ml3ZaPkW6u/l7zLaeYElU03tiyORHxd/j8=",
                Role = "admin"
            },
            new User
            {
                Id = "0875206c-a23a-4136-9994-82883dd03073",
                Username = "user",
                Password = "jRBSSE+HuB4PSa52gxD71nFbKdV6YyLvkJZvk9mT1Ao=", // user
                PasswordSalt = "s0eqy73U2hqAEHcoQ4LAo6maSshjllhQzoh28Ag7W4o="
            },
        };

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = Users.SingleOrDefault((user) => user.Username.Equals(loginRequest.Username));
            if (user == null)
                return null;

            var passwordHash = TokenHelper.Hash(loginRequest.Password, Convert.FromBase64String(user.PasswordSalt));
            if (!user.Password.Equals(passwordHash))
                return null;

            var token = await Task.Run(() => TokenHelper.GenerateAccessToken(user));
            return new LoginResponse { AccessToken = token };
        }

        public Task SignupAsync(LoginRequest request) => throw new NotImplementedException(); // throw exception because we are not using this function
    }
}

