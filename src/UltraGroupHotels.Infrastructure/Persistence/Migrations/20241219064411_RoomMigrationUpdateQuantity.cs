using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoomMigrationUpdateQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity_guests_adults",
                table: "rooms");

            migrationBuilder.RenameColumn(
                name: "quantity_guests_children",
                table: "rooms",
                newName: "quantity_guests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity_guests",
                table: "rooms",
                newName: "quantity_guests_children");

            migrationBuilder.AddColumn<int>(
                name: "quantity_guests_adults",
                table: "rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
