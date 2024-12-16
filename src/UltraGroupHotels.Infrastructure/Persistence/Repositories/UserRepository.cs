using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .Where(u => u.Email == email)
            .SingleOrDefaultAsync(cancellationToken);

        return user;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
    }
}
