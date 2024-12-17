using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoomMigrationUpdateUniqueSnackCaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_bookings_BookingId",
                table: "guests");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_hotels_HotelId",
                table: "rooms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rooms",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "rooms",
                newName: "hotel_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "hotels",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "guests",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "guests",
                newName: "booking_id");

            migrationBuilder.RenameIndex(
                name: "IX_guests_BookingId",
                table: "guests",
                newName: "IX_guests_booking_id");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_bookings_booking_id",
                table: "guests",
                column: "booking_id",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_hotels_hotel_id",
                table: "rooms",
                column: "hotel_id",
                principalTable: "hotels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_bookings_booking_id",
                table: "guests");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_hotels_hotel_id",
                table: "rooms");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "hotel_id",
                table: "rooms",
                newName: "HotelId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "hotels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "guests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "booking_id",
                table: "guests",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_guests_booking_id",
                table: "guests",
                newName: "IX_guests_BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_guests_bookings_BookingId",
                table: "guests",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_hotels_HotelId",
                table: "rooms",
                column: "HotelId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
