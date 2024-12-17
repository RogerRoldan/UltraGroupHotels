using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Guest;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.DateOfBirth)
            .IsRequired();

        builder.Property(g => g.Gender)
            .HasConversion(
            gender => gender.Value,
            value => Gender.Create(value)!)
            .IsRequired();

        builder.Property(g => g.TypeDocument)
            .HasConversion(
            typeDocument => typeDocument.Value,
            value => TypeDocument.Create(value)!)
            .IsRequired();

        builder.Property(g => g.DocumentNumber)
            .HasConversion(
            documentNumber => documentNumber.Value,
            value => new DocumentNumber(value))
            .IsRequired();

        builder.HasIndex(g => g.Email)
            .IsUnique();

        builder.Property(g => g.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.PhoneNumber)
            .HasConversion(
            phoneNumber => phoneNumber.Value,
            value => PhoneNumber.Create(value)!)
            .HasMaxLength(20)
            .IsRequired();           

        builder.HasOne<Booking>()
            .WithMany()
            .HasForeignKey(g => g.BookingId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}