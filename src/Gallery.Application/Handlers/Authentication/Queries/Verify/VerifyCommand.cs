using Gallery.Application.Handlers.Authentication.Common;
using MediatR;

namespace Gallery.Application.Handlers.Authentication.Queries.Verify;

public record VerifyCommand(
    string Email,
    string VerificationToken
) : IRequest<AuthenticationResponse>;