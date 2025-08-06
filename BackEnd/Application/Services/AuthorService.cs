using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;


namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly PasswordHasher<object> _passwordHasher = new();

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Author?> GetByPenNameAsync(string penName) => await _repository.GetByPenNameAsync(penName);

        public async Task<Author?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<bool> CreateAuthorWithPasswordAsync(string penName, string email, string password)
        {
            var hashedPassword = HashPassword(password);

            var newAuthor = new Author
            {
                PenName = penName,
                Email = email,
                HashedPassword = hashedPassword,
                Role = "User"
            };

            return await _repository.CreateAsync(newAuthor);
        }

        public string HashPassword(string password) =>
            _passwordHasher.HashPassword(null, password);

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> UpdateAsync(Author author) => await _repository.UpdateAsync(author);

        public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}