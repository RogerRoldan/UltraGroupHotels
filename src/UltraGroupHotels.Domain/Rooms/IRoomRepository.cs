namespace UltraGroupHotels.Domain.Rooms;

public interface IRoomRepository
{
    Task<List<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    void Add(Room room);
    void Update(Room room);
    void Delete(Room room);
}
