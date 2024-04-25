using FastEndpoints;
using Gallery.Application.Handlers.Authentication.Queries.Login;
using MediatR;
namespace Gallery.API.Features.Sample;

public class LoginEndpoint(ISender _mediator) : Endpoint<LoginCommand, LoginResponse>
{
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous(); // Comment this line to allow authorization
    }

    public override async Task HandleAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command);
        await SendAsync(response);
    }
}