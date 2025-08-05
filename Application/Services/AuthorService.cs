using Domain.Models;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        
        private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
        public AuthorService(IAuthorRepository repository) {  _repository = repository; }
        
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Author?> GetByPenNameAsync(string penName)
        {
            return await _repository.GetByPenNameAsync(penName);
        }
        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateAuthorWithPasswordAsync(string penName, string email, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(null, password);

            var newAuthor = new Author
            {
                PenName = penName,
                Email = email,
                HashedPassword = hashedPassword,
                Role = "User"
            };

            return await _repository.CreateAsync(newAuthor);
        }

        public async Task<bool> UpdateAsync(Author author)
        {
            return await _repository.UpdateAsync(author);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
