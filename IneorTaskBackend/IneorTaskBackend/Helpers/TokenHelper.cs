using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IneorTaskBackend.Model.Login;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace IneorTaskBackend.Helpers
{
    /// <summary>
    /// Helper for generating access and refresh tokens
    /// </summary>
    public static class TokenHelper
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Secret = "ZHNkZjM0RjNjM2hqNEZlXzEyMzIpMj0/PSJkc0xLU05pdWdzdXlmMzJHI2gjNTZ5aldfUkcjNTl2amhOVFJWZXc=";

        public static async Task<string> GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(Secret);
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.GivenName, user.Username),
            });

            if (!string.IsNullOrWhiteSpace(user.Role))
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = Issuer,
                Audience = Audience,
                Expires = DateTime.Now.AddHours(6), // valid for 6 hours by default
                SigningCredentials = signingCredentials,

            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.Run(() => tokenHandler.WriteToken(securityToken));
        }

        public static async Task<string> GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();
            await Task.Run(() => randomNumberGenerator.GetBytes(secureRandomBytes));

            var refreshToken = Convert.ToBase64String(secureRandomBytes);
            return refreshToken;
        }

        public static byte[] GetSecureSalt() => RandomNumberGenerator.GetBytes(32);
        public static string Hash(string password, byte[] salt) => Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, iterationCount: 100000, 32));
    }
}

