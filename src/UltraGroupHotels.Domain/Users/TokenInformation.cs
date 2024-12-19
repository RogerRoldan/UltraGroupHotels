namespace UltraGroupHotels.Domain.Users;

public record TokenInformation(Guid Id, string FullName, string Email, string Role);
