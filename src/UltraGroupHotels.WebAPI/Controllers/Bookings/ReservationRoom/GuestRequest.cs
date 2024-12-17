namespace UltraGroupHotels.WebAPI.Controllers.Bookings.ReservationRoom;

public record GuestRequest(
    string FirstName,
    string LastName,
    DateOnly DateOfBirth,
    string Gender,
    string TypeDocument,
    string DocumentNumber,
    string Email,
    string PhoneNumber);
