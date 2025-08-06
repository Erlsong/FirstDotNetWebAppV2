using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<object> _passwordHasher = new();

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<User?> GetByEmailAsync(string email) => await _repository.GetByEmailAsync(email);

        public async Task<User?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateUserWithPasswordAsync(string penName, string email, string password)
        {
            var hashedPassword = HashPassword(password);

            var newUser = new User
            {
                PenName = penName,
                Email = email,
                HashedPassword = hashedPassword,
                Role = "User"
            };

            return await _repository.CreateAsync(newUser);
        }

        public string HashPassword(string password) =>
            _passwordHasher.HashPassword(null, password);

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> UpdateAsync(User user) => await _repository.UpdateAsync(user);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}