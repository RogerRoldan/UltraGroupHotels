using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(e => e.Email)
            .IsUnique();

        builder.Property(u => u.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.Role)
            .HasConversion(
                role => role.Value,
                value => Role.FromValue(value))
            .HasMaxLength(50);
    }
}
