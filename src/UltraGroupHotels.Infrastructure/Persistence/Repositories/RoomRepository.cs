using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Room room)
    {
        _context.Rooms.Add(room);
    }

    public void Delete(Room room)
    {
        _context.Rooms.Remove(room);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        var exists = _context.Rooms.AnyAsync(r => r.Id == id);

        return exists;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        var rooms = await _context.Rooms.ToListAsync();

        return rooms;
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        return room;
    }

    public void Update(Room room)
    {
        _context.Rooms.Update(room);
    }
}