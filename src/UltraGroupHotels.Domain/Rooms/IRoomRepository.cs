namespace UltraGroupHotels.Domain.Rooms;

public interface IRoomRepository
{
    Task<List<Room>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsByRoomNumberAndHotelIdAsync(int roomNumber, Guid hotelId, CancellationToken cancellationToken = default);
    void Add(Room room);
    void Update(Room room);
    void Delete(Room room);
}
