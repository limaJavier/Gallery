using Gallery.Application.Common;
using Gallery.Application.Handlers.Authentication.Commands.Register;
using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Interfaces.Authentication;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class RegisterCommandHandler(IUnitOfWork _unitOfWork, IPasswordHasher<User> _passwordHasher, ITokenGenerator _tokenGenerator, IEmailSender _emailSender) : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userRepository = _unitOfWork.GetRepository<User>();

        // Check email is not registered
        var user = userRepository.Find(filters: [user => user.Email == command.Email]);

        if (user is not null)
            throw new Exception("Email was already registered");

        // Create user
        user = new User()
        {
            Name = command.Name,
            LastName = command.LastName,
            Email = command.Email,
            VerificationToken = _tokenGenerator.Generate() // Generate verification token
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, command.Password); // Hash password

        // Persist changes
        await userRepository.InsertAsync(user);
        await _unitOfWork.SaveAsync();

        var email = new EmailRequest(["ima.nolan@ethereal.email"], "Gallery Verification Email", @$"
        Thanks for choosing Gallery as your images host. Please click the following link to access our platform: <a href='http://localhost:5045/verify?email={command.Email}&verificationToken={user.VerificationToken}' target='_blank'>Gallery Verify</a>
        ");
        await _emailSender.SendEmail(email);

        var response = new AuthenticationResponse(user.Email);

        return response;
    }
}
