namespace UltraGroupHotels.Application.Implementations.Common.Email;

public interface IEmailService
{
    void Send(string email, string subject, string body);
}
