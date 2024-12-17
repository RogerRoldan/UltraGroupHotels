using System.Security.Cryptography;
using System.Text;
using UltraGroupHotels.Application.Users.Common.Authorization;

namespace UltraGroupHotels.Infrastructure.Authorization;

public class HashingService : IHashingService
{
    public string HashPassword(string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashedBytes = SHA256.HashData(passwordBytes);
        return Convert.ToBase64String(hashedBytes);
    }
    public bool VerifyHash(string password, string hashedPassword)
    {
        return HashPassword(password) == hashedPassword;
    }
}
