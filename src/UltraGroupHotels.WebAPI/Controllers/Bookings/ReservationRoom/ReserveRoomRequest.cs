using UltraGroupHotels.Application.Bookings.ReserveRoom;

namespace UltraGroupHotels.WebAPI.Controllers.Bookings.ReservationRoom;

public record ReserveRoomRequest(
    Guid RoomId,
    Guid CustomerId,
    DateOnly StartDate,
    DateOnly EndDate,
    string EmergencyContactFullName,
    string EmergencyContactPhoneNumber,
    List<GuestRequest> Guests);


