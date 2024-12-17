using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Booking>> GetAllBookingsAsync(CancellationToken cancellationToken = default)
        {
            var hotels = await _context.Booking.ToListAsync(cancellationToken);

            return hotels;
        }

        public async Task<Booking?> GetBookingByIdAsync(Guid bookingId, CancellationToken cancellationToken = default)
        {
            var booking = await _context.Booking.FirstOrDefaultAsync(x => x.Id == bookingId, cancellationToken);


            return booking;
        }

        public void Add(Booking booking)
        {
            _context.Booking.Add(booking);
        }

        public async Task<bool> ExistsOverlappingReservationAsync(Room room, DateRange duration, CancellationToken cancellationToken = default)
        {
            bool exists = await _context.Booking.AnyAsync(
                booking =>
                    booking.RoomId == room.Id &&
                    booking.Duration.StartDate <= duration.EndDate &&
                    booking.Duration.EndDate >= duration.StartDate &&
                    StatusBookingsActive.StatusBookingActive.Contains(booking.StatusBooking),
                cancellationToken);

            return exists;
        }

    }
}
