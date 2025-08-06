// Infrastructure/Data/AlbumRepository.cs
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums.ToListAsync();
        }
        public async Task<IEnumerable<Album>> GetAllByUserAsync(int userId)
        {
            return await _context.Albums.Where(a=>a.UserId == userId).ToListAsync();
        }

        public async Task<Album?> GetByIdAsync(int id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Album Album)
        {
            _context.Albums.Add(Album);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Album Album)
        {
            _context.Albums.Update(Album);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Album = await _context.Albums.FindAsync(id);
            if (Album == null) return false;

            _context.Albums.Remove(Album);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
