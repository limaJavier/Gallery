using Gallery.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gallery.Infrastructure;

public static class DependencyInjection
{
    private const string GALLERY_CONNECTION = "GalleryConnection";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {

        services.AddDbContext<GalleryDbContext>(options => 
            options.UseMySQL(configuration.GetConnectionString(GALLERY_CONNECTION)!));

        return services;
    }
}