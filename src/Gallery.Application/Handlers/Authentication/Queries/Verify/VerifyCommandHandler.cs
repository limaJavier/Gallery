using Gallery.Application.Handlers.Authentication.Common;
using Gallery.Application.Interfaces.Persistence;
using Gallery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gallery.Application.Handlers.Authentication.Queries.Verify;

public class VerifyCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<VerifyCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(VerifyCommand command, CancellationToken cancellationToken)
    {
        var userRepository = _unitOfWork.GetRepository<User>();

        // Check email existence
        var user = userRepository.Find(filters: [user => user.Email == command.Email]) ?? throw new Exception("Email was not found");

        // Check verification code
        if(user.VerificationToken != command.VerificationToken)
            throw new Exception("Wrong verification code");
        
        // Verify user
        user.Verified = true;
        // Persist changes
        userRepository.Update(user);
        await _unitOfWork.SaveAsync();

        var response = new AuthenticationResponse(user.Email);

        return response;
    }
}
