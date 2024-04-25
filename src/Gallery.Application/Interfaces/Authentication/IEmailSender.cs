using Gallery.Application.Common;

namespace Gallery.Application.Interfaces.Authentication;

public interface IEmailSender
{
    Task SendEmail(EmailRequest request);
}