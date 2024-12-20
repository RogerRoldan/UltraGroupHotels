namespace UltraGroupHotels.Domain.Hotels;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Hotel hotel);
    void Update(Hotel hotel);
    void Delete(Hotel hotel);
    Task<List<Hotel>> GetHotelByCityAsync(string city, CancellationToken cancellationToken = default);
}
