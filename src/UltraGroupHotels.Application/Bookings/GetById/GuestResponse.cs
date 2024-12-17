namespace UltraGroupHotels.Application.Bookings.GetById;

public record GuestResponse(
                            string FirstName,
                            string LastName,
                            DateOnly DateOfBirth,
                            string Gender,
                            string TypeDocument,
                            string DocumentNumber,
                            string Email,
                            string PhoneNumber);
