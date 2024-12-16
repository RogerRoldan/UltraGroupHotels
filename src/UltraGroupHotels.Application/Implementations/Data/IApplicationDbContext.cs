using UltraGroupHotels.Domain.Hotels;
using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Rooms;
using UltraGroupHotels.Domain.Users;
using UltraGroupHotels.Domain.Bookings;

namespace UltraGroupHotels.Application.Implementations.Data;

public interface IApplicationDbContext
{
    DbSet<Hotel> Hotels { get; set; }
    DbSet<Room> Rooms { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Booking> Booking { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
