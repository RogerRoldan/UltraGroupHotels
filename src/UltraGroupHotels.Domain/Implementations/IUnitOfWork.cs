namespace UltraGroupHotels.Domain.Implementations;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
