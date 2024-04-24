namespace Gallery.Application.Handlers.Authentication.Common;

public record AuthenticationResponse(
    string Email,
    string Token
);