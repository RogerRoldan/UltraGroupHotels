namespace UltraGroupHotels.Domain.Hotels;

public interface IHotelRepository
{
    Task<List<Hotel>> GetAllAsync();
    Task<Hotel?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    void Add(Hotel hotel);
    void Update(Hotel hotel);
    void Delete(Hotel hotel);
}
