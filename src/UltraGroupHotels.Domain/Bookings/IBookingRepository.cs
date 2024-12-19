using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetBookingByIdAsync(Guid bookingId, CancellationToken cancellationToken = default);
    Task<List<Booking>> GetAllBookingsAsync(CancellationToken cancellationToken = default);
    void Add(Booking booking);
    Task<bool> ExistsOverlappingReservationAsync(Room room, DateRange duration, CancellationToken cancellationToken = default);
    Task<List<Booking>> GetOverlappingReservationsAsync(DateRange duration, CancellationToken cancellationToken = default);
}
