using Gallery.Application.Common;
using Gallery.Application.Interfaces.Authentication;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Gallery.Infrastructure.Authentication;

public class EmailSender : IEmailSender
{
    private SmtpSettings _smtpSettings;
    public EmailSender(IOptions<SmtpSettings> smtpOptions)
    {
        _smtpSettings = smtpOptions.Value;
    }
    public void SendEmail(EmailRequest request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_smtpSettings.From));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
        foreach (var to in request.To)
            email.To.Add(MailboxAddress.Parse(to));

        try
        {
            using var smtp = new SmtpClient();
            smtp.Connect(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_smtpSettings.From, _smtpSettings.Password);
            smtp.Send(email);
        }
        catch
        {
            throw new Exception("Verification email could not be send");
        }
    }
}
