using UltraGroupHotels.Domain.Hotels;
using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Rooms;
using UltraGroupHotels.Domain.Users;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Guest;

namespace UltraGroupHotels.Application.Implementations.Data;

public interface IApplicationDbContext
{
    DbSet<Hotel> Hotels { get; set; }
    DbSet<Room> Rooms { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Booking> Booking { get; set; }
    public DbSet<Guest> Guests { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
