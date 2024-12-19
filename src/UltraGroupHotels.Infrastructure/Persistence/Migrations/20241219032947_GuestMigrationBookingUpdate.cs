using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GuestMigrationBookingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "bookings",
                newName: "titular_guest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titular_guest",
                table: "bookings",
                newName: "user_id");
        }
    }
}
