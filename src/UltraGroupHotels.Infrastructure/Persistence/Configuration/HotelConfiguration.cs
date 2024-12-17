using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("hotels");

        builder.HasKey(h => h.Id);
        builder.Property(h => h.Id)
            .HasColumnName("id");

        builder.Property(h => h.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(h => h.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(h => h.PhoneNumber)
            .HasColumnName("phone_number")
            .HasConversion(
                phoneNumber => phoneNumber.Value,
                value => PhoneNumber.Create(value)!)
            .HasMaxLength(20);

        builder.OwnsOne(h => h.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .HasColumnName("address_country")
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.State)
                .HasColumnName("address_state")
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.City)
                .HasColumnName("address_city")
                .HasMaxLength(100)
                .IsRequired();

            addressBuilder.Property(a => a.ZipCode)
                .HasColumnName("address_zip_code")
                .HasMaxLength(10)
                .IsRequired(false);

            addressBuilder.Property(a => a.Street)
                .HasColumnName("address_street")
                .HasMaxLength(100)
                .IsRequired();
        });

    }
}
