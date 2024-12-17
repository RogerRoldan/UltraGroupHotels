using Microsoft.Extensions.Options;
using System.Net.Mail;
using UltraGroupHotels.Application.Implementations.Common.Email;

namespace UltraGroupHotels.Infrastructure.Email;

public class EmailService : IEmailService
{
    public readonly EmailOptions _emailOptions;

    public EmailService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }

    public void Send(string email, string subject, string body)
    {
        MailMessage mail = new(_emailOptions.Email, email, subject, body);

        SmtpClient client = new(_emailOptions.Host, _emailOptions.Port)
        {
            Credentials = new System.Net.NetworkCredential(_emailOptions.Email, _emailOptions.Password),
            EnableSsl = true
        };

        client.Send(mail);

        return;
    }
}