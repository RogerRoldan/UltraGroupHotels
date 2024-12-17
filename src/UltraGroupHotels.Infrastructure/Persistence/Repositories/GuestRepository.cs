using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Guest;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly ApplicationDbContext _context;

    public GuestRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<List<Guest>> GetAllAsync(CancellationToken cancellationToken)
    {
        var guests = await _context.Guests.ToListAsync(cancellationToken);

        return guests;
    }

    public async Task<Guest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var guest = await _context.Guests.FirstOrDefaultAsync(g => g.Id == id, cancellationToken);

        return guest;
    }

    public void Add(Guest guest)
    {
        _context.Guests.Add(guest);
    }

    public void AddRange(List<Guest> guests)
    {
        _context.Guests.AddRange(guests);
    }

}