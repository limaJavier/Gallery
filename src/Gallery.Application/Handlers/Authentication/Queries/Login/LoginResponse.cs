namespace Gallery.Application.Handlers.Authentication.Queries.Login;

public record LoginResponse(
    string Email,
    string Token
);