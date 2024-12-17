using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.SharedValueObjects;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.RoomId)
            .HasColumnName("room_id")
            .IsRequired();

        builder.Property(b => b.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.OwnsOne(b => b.Duration, d =>
        {
            d.Property(dr => dr.StartDate)
                .HasColumnName("start_date")
                .IsRequired();

            d.Property(dr => dr.EndDate)
                .HasColumnName("end_date")
                .IsRequired();
        });

        builder.Property(b => b.TaxesPercentage)
            .HasConversion(
                taxes => taxes.Value,
                value => Taxes.FromValue(value))
            .HasColumnName("taxes_percentage")
            .HasColumnType("decimal(5, 2)");

        builder.OwnsOne(b => b.TotalTaxes, t =>
        {
            t.Property(m => m.Amount)
                .HasColumnName("total_taxes_amount")
                .IsRequired();

            t.Property(m => m.Currency)
                .HasColumnName("total_taxes_currency")
                .HasConversion(
                    currency => currency.Code,
                    value => Currency.FromCode(value));
        });

        builder.OwnsOne(b => b.PriceDuration, p =>
        {
            p.Property(m => m.Amount)
                .HasColumnName("price_duration_amount")
                .IsRequired();

            p.Property(m => m.Currency)
                .HasColumnName("price_duration_currency")
                .HasConversion(
                    currency => currency.Code,
                    value => Currency.FromCode(value));
        });

        builder.OwnsOne(b => b.TotalPrice, p =>
        {
            p.Property(m => m.Amount)
                .HasColumnName("total_price_amount")
                .IsRequired();

            p.Property(m => m.Currency)
                .HasColumnName("total_price_currency")
                .HasConversion(
                    currency => currency.Code,
                    value => Currency.FromCode(value));
        });

        builder.Property(booking => booking.StatusBooking)
            .HasColumnName("status_booking")
            .HasConversion<int>();

        builder.OwnsOne(b => b.EmergencyContact, e =>
        {
            e.Property(ec => ec.FullName)
                .HasColumnName("emergency_contact_full_name")
                .HasMaxLength(200)
                .IsRequired();

            e.Property(ec => ec.PhoneNumber)
                .HasColumnName("emergency_contact_phone_number")
                .HasMaxLength(20)
                .IsRequired()
                .HasConversion(
                    phoneNumber => phoneNumber.Value,
                    value => PhoneNumber.Create(value)!);
        });

        builder.Property(b => b.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

    }
}
