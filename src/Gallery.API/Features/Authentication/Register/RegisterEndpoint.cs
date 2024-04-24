using FastEndpoints;
using Gallery.Application.Handlers.Authentication.Commands.Register;
using Gallery.Application.Handlers.Authentication.Common;
using MediatR;
namespace Gallery.API.Features.Sample;

public class RegisterEndpoint(ISender _mediator) : Endpoint<RegisterCommand, AuthenticationResponse>
{
    public override void Configure()
    {
        Post("/register");
        AllowAnonymous(); // Comment this line to allow authorization
    }

    public override async Task HandleAsync(RegisterCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command);
        await SendAsync(response);
    }
}