namespace UltraGroupHotels.Infrastructure.Email;

public sealed class EmailOptions
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool EnableSSL { get; set; }
}
