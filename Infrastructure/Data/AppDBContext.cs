using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Album> Albums { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Album>().HasKey(a => a.Id);
            modelBuilder.Entity<Post>().HasKey(a => a.Id);
            modelBuilder.Entity<Comment>().HasKey(a => a.Id);
        }
    }
}
