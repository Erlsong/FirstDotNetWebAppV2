// Infrastructure/Data/PostRepository.cs
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllByUserAsync(int userId)
        {
            return await _context.Posts.Where(p=> p.UserId == userId).ToListAsync(); 
        }

        public async Task<IEnumerable<Post>> GetAllByAlbumAsync(int albumId)
        {
            return await _context.Posts.Where(p => p.AlbumId == albumId).ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Post Post)
        {
            _context.Posts.Add(Post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Post Post)
        {
            _context.Posts.Update(Post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Post = await _context.Posts.FindAsync(id);
            if (Post == null) return false;

            _context.Posts.Remove(Post);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
