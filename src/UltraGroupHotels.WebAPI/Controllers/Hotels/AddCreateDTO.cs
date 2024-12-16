namespace UltraGroupHotels.WebAPI.Controllers.Hotels;

public record AddCreateDTO(string Name, string Description, string Country, string State, string City, string ZipCode, string Street, bool IsActive, string PhoneNumber);
