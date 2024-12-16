using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Hotels;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _context;

    public HotelRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
    }

    public void Delete(Hotel hotel)
    {
        _context.Hotels.Remove(hotel);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        var exists = _context.Hotels.AnyAsync(h => h.Id == id);

        return exists;
    }

    public async Task<List<Hotel>> GetAllAsync()
    {
        var hotels = await _context.Hotels.ToListAsync();

        return hotels;
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id);


        return hotel;
    }

    public void Update(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
    }
}
