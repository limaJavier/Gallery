using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gallery.Infrastructure.Persistence;

public class GalleryContextFactory : IDesignTimeDbContextFactory<GalleryDbContext>
{
    public GalleryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GalleryDbContext>();
        optionsBuilder.UseMySQL(args[0]);

        return new GalleryDbContext(optionsBuilder.Options);
    }
}