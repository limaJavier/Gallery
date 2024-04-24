using Gallery.Application.Handlers.Authentication.Commands.Register;
using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class RegisterCommandHandler(IUnitOfWork _unitOfWork, IPasswordHasher<User> _passwordHasher) : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userRepository = _unitOfWork.GetRepository<User>();

        var user = userRepository.Find(filters: [user => user.Email == command.Email]);

        if (user is not null)
            throw new Exception("Email was already registered");
    

        user = new User() {
            Name = command.Name,
            LastName = command.LastName,
            Email = command.Email
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, command.Password);
        
        await userRepository.InsertAsync(user);
        await _unitOfWork.SaveAsync();

        var response = new AuthenticationResponse(
            user.Email,
            "fake_token"
        );

        return response;
    }
}
