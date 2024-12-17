namespace UltraGroupHotels.WebAPI.Controllers.Authorization.Register;

public record RegisterUserRequest(string FullName, string Email, string Password, string Role);

