using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UltraGroupHotels.Domain.CommonValueObjects;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Rooms;

namespace UltraGroupHotels.Infrastructure.Persistence.Configuration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .HasColumnName("id");

        builder.Property(r => r.HotelId)
            .HasColumnName("hotel_id")
            .IsRequired();

        builder.Property(r => r.RoomNumber)
            .HasColumnName("room_number")
            .IsRequired();

        builder.OwnsOne(r => r.QuantityGuests, quantityGuestsBuilder =>
        {
            quantityGuestsBuilder.Property(qg => qg.Adults)
                .HasColumnName("quantity_guests_adults")
                .IsRequired();

            quantityGuestsBuilder.Property(qg => qg.Children)
                .HasColumnName("quantity_guests_children")
                .IsRequired();
        });

        builder.Property(r => r.RoomType)
            .HasColumnName("room_type")
            .IsRequired()
            .HasConversion(
                roomType => roomType.Value,
                value => RoomType.Create(value)
            );

        builder.OwnsOne(r => r.BaseCost, costBuilder =>
        {
            costBuilder.Property(cost => cost.Currency)
                .HasColumnName("base_cost_currency")
                .HasConversion(
                    currency => currency.Code,
                    code => Currency.FromCode(code));
        });

        builder.Property(r => r.Taxes)
            .HasColumnName("taxes")
            .HasConversion(
                taxes => taxes.Value,
                value => Taxes.FromValue(value))
            .HasColumnType("decimal(4, 2)");

        builder.Property(r => r.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne<Hotel>()
            .WithMany()
            .HasForeignKey(r => r.HotelId);

        builder.HasIndex(r => new { r.HotelId, r.RoomNumber })
            .HasDatabaseName("IX_Rooms_HotelId_RoomNumber")
            .IsUnique();

    }
}
