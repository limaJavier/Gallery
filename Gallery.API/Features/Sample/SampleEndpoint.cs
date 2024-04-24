using FastEndpoints;
namespace Gallery.API.Features.Sample;

public class SampleEndpoint : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("/sample");
        AllowAnonymous(); // Comment this line to allow authorization
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        await SendAsync("Viva Cuba Libre!");
    }
}