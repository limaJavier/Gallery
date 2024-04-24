using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gallery.Application.Handlers.Authentication.Queries.Login;

public class LoginCommandHandler(IUnitOfWork _unitOfWork, IPasswordHasher<User> _passwordHasher) : IRequestHandler<LoginCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var userRepository = _unitOfWork.GetRepository<User>();

        var user = userRepository.Find(filters: [user => user.Email == command.Email]) ?? throw new Exception("Email was not found");

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password);

        if (result.ToString() is not "Success")
            throw new Exception("Wrong password");

        var response = new AuthenticationResponse(
            user.Email,
            "fake_token"
        );

        await Task.CompletedTask;
        return response;
    }
}
