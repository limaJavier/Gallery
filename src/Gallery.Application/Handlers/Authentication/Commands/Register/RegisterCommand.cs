using Gallery.Application.Handlers.Authentication.Common;
using MediatR;

namespace Gallery.Application.Handlers.Authentication.Commands.Register;

public record RegisterCommand(
    string Name,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;