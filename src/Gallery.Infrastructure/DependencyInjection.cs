using Gallery.Application.Interfaces.Authentication;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Infrastructure.Authentication;
using Gallery.Infrastructure.Persistence;
using Gallery.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gallery.Infrastructure;

public static class DependencyInjection
{
    private const string GALLERY_CONNECTION = "GalleryConnection";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        var smtpSettings = new SmtpSettings();
        configuration.Bind(SmtpSettings.SECTION_NAME, smtpSettings);
        services.AddSingleton(Options.Create(smtpSettings));
        
        services.AddDbContext<GalleryDbContext>(options =>
            options.UseMySQL(configuration.GetConnectionString(GALLERY_CONNECTION)!));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<ITokenGenerator, TokenGenerator>();

        return services;
    }
}