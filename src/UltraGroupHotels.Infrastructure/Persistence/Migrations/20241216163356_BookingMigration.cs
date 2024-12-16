using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BookingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    taxes_percentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    TotalTaxes_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalTaxes_Currency = table.Column<string>(type: "text", nullable: false),
                    PriceDuration_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceDuration_Currency = table.Column<string>(type: "text", nullable: false),
                    TotalPrice_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice_Currency = table.Column<string>(type: "text", nullable: false),
                    StatusBooking = table.Column<int>(type: "integer", nullable: false),
                    emergency_contact_full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    emergency_contact_phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
