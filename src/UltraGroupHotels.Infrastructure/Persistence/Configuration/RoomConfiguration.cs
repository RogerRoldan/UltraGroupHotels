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
        builder.ToTable("Rooms");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.RoomNumber)
            .IsRequired();

        builder.OwnsOne(r => r.QuantityGuests, quantityGuestsBuilder =>
        {
            quantityGuestsBuilder.Property(qg => qg.Adults)
                .IsRequired();

            quantityGuestsBuilder.Property(qg => qg.Children)
                .IsRequired();
        });

        builder.Property(r => r.RoomType)
            .IsRequired() // Obliga a que RoomType sea obligatorio
            .HasConversion(
                roomType => roomType.Value, // De RoomType a string (para guardar en la DB)
                value => RoomType.Create(value) // De string a RoomType (para uso en la aplicación)
            );


        builder.OwnsOne(r => r.BaseCost, costBuilder =>
        {
            costBuilder.Property(cost => cost.Currency)
                .HasConversion(
                    currency => currency.Code,
                    code => Currency.FromCode(code));
        });

        builder.Property(room => room.Taxes)
     .HasConversion(
         taxes => taxes.Value,
         value => Taxes.FromValue(value))
     .HasColumnType("decimal(4, 2)");

        builder.Property(r => r.IsActive)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.HasOne<Hotel>()
            .WithMany()
            .HasForeignKey(r => r.HotelId);

    }
}
