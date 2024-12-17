using UltraGroupHotels.Domain.Guest;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public interface IGuestRepository
{
    Task<List<Guest>> GetAllAsync(CancellationToken cancellationToken);
    Task<Guest?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Add(Guest guest);
    void AddRange(List<Guest> guests);

}