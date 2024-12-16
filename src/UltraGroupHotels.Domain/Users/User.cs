using UltraGroupHotels.Domain.Implementations;

namespace UltraGroupHotels.Domain.Users;

public class User : Entity
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; }


    public User(Guid id, string fullName, string email, string password, Role role)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        Password = password;
        Role = role;
        CreatedAt = DateTime.UtcNow;
    }

    private User()
    {
    }

}
