using Gallery.Application.Common;

namespace Gallery.Application.Interfaces.Authentication;

public interface IEmailSender
{
    void SendEmail(EmailRequest request);
}