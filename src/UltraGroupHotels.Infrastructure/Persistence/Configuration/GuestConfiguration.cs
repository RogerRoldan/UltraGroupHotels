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
        builder.ToTable("guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.BookingId)
            .HasColumnName("booking_id");

        builder.Property(g => g.Id)
            .HasColumnName("id");

        builder.Property(g => g.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.DateOfBirth)
            .HasColumnName("date_of_birth")
            .IsRequired();

        builder.Property(g => g.Gender)
            .HasColumnName("gender")
            .HasConversion(
                gender => gender.Value,
                value => Gender.Create(value)!)
            .IsRequired();

        builder.Property(g => g.TypeDocument)
            .HasColumnName("type_document")
            .HasConversion(
                typeDocument => typeDocument.Value,
                value => TypeDocument.Create(value)!)
            .IsRequired();

        builder.Property(g => g.DocumentNumber)
            .HasColumnName("document_number")
            .HasConversion(
                documentNumber => documentNumber.Value,
                value => new DocumentNumber(value))
            .IsRequired();

        builder.HasIndex(g => g.Email)
            .HasDatabaseName("IX_guests_email")
            .IsUnique();

        builder.Property(g => g.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.PhoneNumber)
            .HasColumnName("phone_number")
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