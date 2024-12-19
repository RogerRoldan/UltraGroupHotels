using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Application.Users.Common.Authorization;

public interface IJwtService
{
    string GenerateJwtToken(User user);
    TokenInformation GetTokenInformation();
}