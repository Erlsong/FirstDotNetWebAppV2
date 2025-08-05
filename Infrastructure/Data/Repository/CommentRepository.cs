// Infrastructure/Data/CommentRepository.cs
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Comment Comment)
        {
            _context.Comments.Add(Comment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Comment Comment)
        {
            _context.Comments.Update(Comment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Comment = await _context.Comments.FindAsync(id);
            if (Comment == null) return false;

            _context.Comments.Remove(Comment);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
