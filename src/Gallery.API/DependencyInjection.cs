using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace Gallery.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddFastEndpoints()
            .SwaggerDocument()
            .ConfigureHttpJsonOptions(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        return services;
    }
}