using Domain.Models;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByPenNameAsync(string penName);
        Task<Author?> GetByIdAsync(int id);
        Task<bool> CreateAuthorWithPasswordAsync(string penName, string email, string password);
        string HashPassword(string password);
        Task<bool> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}
