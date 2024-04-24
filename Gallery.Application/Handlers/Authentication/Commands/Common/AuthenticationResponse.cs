namespace Gallery.Application.Handlers.Authentication.Commands.Common;

public record AuthenticationResponse(
    string Email,
    string Token
);