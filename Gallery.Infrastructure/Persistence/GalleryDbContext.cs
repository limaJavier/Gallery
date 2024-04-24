using Gallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Infrastructure.Persistence;

public class GalleryDbContext(DbContextOptions<GalleryDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .HasIndex(album => new
            {
                album.Name,
                album.UserId
            })
            .IsUnique();
    }
}