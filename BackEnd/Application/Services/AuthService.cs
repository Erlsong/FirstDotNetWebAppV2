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
        private readonly IAuthorService _authorService;
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public AuthService(IOptions<JwtSettings> options, IAuthorService authorService)
        {
            _jwtSettings = options.Value;
            _authorService = authorService;
        }

        public async Task<string?> AuthenticateAsync(string penName, string password)
        {
            var author = await _authorService.GetByPenNameAsync(penName);
            if (author == null)
                return null;

            var verifyResult = _passwordHasher.VerifyHashedPassword(null, author.HashedPassword, password);
            if (verifyResult != PasswordVerificationResult.Success)
                return null;

            return GenerateToken(author);
        }

        public string GenerateToken(Author author)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, author.Id.ToString()),
                new Claim(ClaimTypes.Name, author.PenName),
                new Claim(ClaimTypes.Role, author.Role)
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
