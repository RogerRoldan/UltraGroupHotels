namespace UltraGroupHotels.Application.Bookings.ReserveRoom;

public record GuestCommand(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Gender,
    string TypeDocument,
    string DocumentNumber,
    string Email,
    string PhoneNumber);