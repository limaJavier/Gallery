using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gallery.Application.Handlers.Authentication.Queries.Login;

public class LoginCommandHandler(IUnitOfWork _unitOfWork, IPasswordHasher<User> _passwordHasher) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var userRepository = _unitOfWork.GetRepository<User>();

        // Check email existence
        var user = userRepository.Find(filters: [user => user.Email == command.Email]) ?? throw new Exception("Email was not found");

        // Check user is verified
        if(!user.Verified)
            throw new Exception("User is not verified. Please click verification link send to your email");

        // Check password is correct
        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password);

        if (result.ToString() is not "Success")
            throw new Exception("Wrong password");

        var response = new LoginResponse(
            user.Email,
            "fake_token"
        );

        await Task.CompletedTask;
        return response;
    }
}
