using AlbumRating.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlbumRating.Data
{
    public class AlbumRatingDbContext : IdentityDbContext<User>
    {
        public AlbumRatingDbContext(DbContextOptions<AlbumRatingDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<UserRatedAlbum> UserRatedAlbums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Connection.CONNECTION_STRING);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
           modelBuilder.Entity<UserRatedAlbum>().HasKey(ura => new { ura.UserId, ura.AlbumId });

        }

    }
}
