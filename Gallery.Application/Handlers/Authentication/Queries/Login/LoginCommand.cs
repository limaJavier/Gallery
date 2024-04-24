using Gallery.Application.Handlers.Authentication.Common;
using MediatR;

namespace Gallery.Application.Handlers.Authentication.Queries.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;