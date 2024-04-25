namespace Gallery.Infrastructure.Authentication;

public class SmtpSettings
{
    public const string SECTION_NAME = "SmtpSettings";
    public string Server { get; set; } = null!;
    public int Port { get; set; }
    public string From { get; set; } = null!;
    public string Password { get; set; } = null!;
}