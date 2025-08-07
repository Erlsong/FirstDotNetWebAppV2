using Application.Interfaces;
using Application.Models;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public AuthService(IOptions<JwtSettings> options, IUserService userService)
        {
            _jwtSettings = options.Value;
            _userService = userService;
        }

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
            {
                Console.WriteLine("The user doesn't exist.");
                return null;
            }

            var verifyResult = _passwordHasher.VerifyHashedPassword(null, user.HashedPassword, password);
            if (verifyResult != PasswordVerificationResult.Success)
            {
                Console.WriteLine("Password Verification failed.");
                return null; }

            return GenerateToken(user);
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.PenName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
