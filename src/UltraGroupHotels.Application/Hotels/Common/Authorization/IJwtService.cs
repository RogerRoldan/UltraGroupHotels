using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Application.Hotels.Common.Authorization;

public interface IJwtService
{
    string GenerateJwtToken(User user);
}