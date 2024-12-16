using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotels");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(h => h.IsActive)
            .IsRequired();

        builder.Property(h => h.PhoneNumber).HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(20);

        builder.OwnsOne(h => h.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.State)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(10)
                .IsRequired(false);

            addressBuilder.Property(a => a.Street)
                .HasMaxLength(100)
                .IsRequired();
        });
    }
}
