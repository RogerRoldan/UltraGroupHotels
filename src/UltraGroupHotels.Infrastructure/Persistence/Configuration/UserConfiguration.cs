using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnName("id");

        builder.Property(u => u.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Email)
            .HasDatabaseName("IX_Users_Email")
            .IsUnique();

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasColumnName("role")
            .HasConversion(
                role => role.Value,
                value => Role.FromValue(value))
            .HasMaxLength(50);

    }
}
