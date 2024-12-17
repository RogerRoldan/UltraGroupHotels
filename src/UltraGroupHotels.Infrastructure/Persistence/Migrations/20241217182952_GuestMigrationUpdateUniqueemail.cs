using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GuestMigrationUpdateUniqueemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_guests_email",
                table: "guests");

            migrationBuilder.CreateIndex(
                name: "IX_guests_email",
                table: "guests",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_guests_email",
                table: "guests");

            migrationBuilder.CreateIndex(
                name: "IX_guests_email",
                table: "guests",
                column: "email",
                unique: true);
        }
    }
}
