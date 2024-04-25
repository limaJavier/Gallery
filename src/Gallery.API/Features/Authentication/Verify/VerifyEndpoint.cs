using FastEndpoints;
using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Handlers.Authentication.Queries.Verify;
using MediatR;
namespace Gallery.API.Features.Sample;

public class VerifyEndpoint(ISender _mediator) : Endpoint<VerifyCommand, AuthenticationResponse>
{
    public override void Configure()
    {
        Get("/verify");
        AllowAnonymous(); // Comment this line to allow authorization
    }

    public override async Task HandleAsync(VerifyCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command);
        await SendAsync(response);
    }
}