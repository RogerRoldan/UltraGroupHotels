using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoomMigrationUpdateUniqueSnackCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "hotels");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "guests");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "bookings");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "Taxes",
                table: "rooms",
                newName: "taxes");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "rooms",
                newName: "room_type");

            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "rooms",
                newName: "room_number");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "rooms",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "rooms",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "QuantityGuests_Children",
                table: "rooms",
                newName: "quantity_guests_children");

            migrationBuilder.RenameColumn(
                name: "QuantityGuests_Adults",
                table: "rooms",
                newName: "quantity_guests_adults");

            migrationBuilder.RenameColumn(
                name: "BaseCost_Currency",
                table: "rooms",
                newName: "base_cost_currency");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "hotels",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "hotels",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "hotels",
                newName: "address_street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "hotels",
                newName: "address_state");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "hotels",
                newName: "address_country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "hotels",
                newName: "address_city");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "hotels",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "hotels",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "hotels",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "guests",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "guests",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "TypeDocument",
                table: "guests",
                newName: "type_document");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "guests",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "guests",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "guests",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "guests",
                newName: "document_number");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "guests",
                newName: "date_of_birth");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_Email",
                table: "guests",
                newName: "IX_guests_email");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_BookingId",
                table: "guests",
                newName: "IX_guests_BookingId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bookings",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "StatusBooking",
                table: "bookings",
                newName: "status_booking");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "bookings",
                newName: "room_id");

            migrationBuilder.RenameColumn(
                name: "TotalTaxes_Currency",
                table: "bookings",
                newName: "total_taxes_currency");

            migrationBuilder.RenameColumn(
                name: "TotalTaxes_Amount",
                table: "bookings",
                newName: "total_taxes_amount");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Currency",
                table: "bookings",
                newName: "total_price_currency");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Amount",
                table: "bookings",
                newName: "total_price_amount");

            migrationBuilder.RenameColumn(
                name: "PriceDuration_Currency",
                table: "bookings",
                newName: "price_duration_currency");

            migrationBuilder.RenameColumn(
                name: "PriceDuration_Amount",
                table: "bookings",
                newName: "price_duration_amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotels",
                table: "hotels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guests",
                table: "guests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guests_bookings_BookingId",
                table: "guests");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_hotels_HotelId",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotels",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guests",
                table: "guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "Hotels");

            migrationBuilder.RenameTable(
                name: "guests",
                newName: "Guests");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "taxes",
                table: "Rooms",
                newName: "Taxes");

            migrationBuilder.RenameColumn(
                name: "room_type",
                table: "Rooms",
                newName: "RoomType");

            migrationBuilder.RenameColumn(
                name: "room_number",
                table: "Rooms",
                newName: "RoomNumber");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Rooms",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Rooms",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "quantity_guests_children",
                table: "Rooms",
                newName: "QuantityGuests_Children");

            migrationBuilder.RenameColumn(
                name: "quantity_guests_adults",
                table: "Rooms",
                newName: "QuantityGuests_Adults");

            migrationBuilder.RenameColumn(
                name: "base_cost_currency",
                table: "Rooms",
                newName: "BaseCost_Currency");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Hotels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Hotels",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "Hotels",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_state",
                table: "Hotels",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "address_country",
                table: "Hotels",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "address_city",
                table: "Hotels",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Hotels",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "Hotels",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "Hotels",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Guests",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Guests",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "type_document",
                table: "Guests",
                newName: "TypeDocument");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Guests",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Guests",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Guests",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "document_number",
                table: "Guests",
                newName: "DocumentNumber");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "Guests",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_guests_email",
                table: "Guests",
                newName: "IX_Guests_Email");

            migrationBuilder.RenameIndex(
                name: "IX_guests_BookingId",
                table: "Guests",
                newName: "IX_Guests_BookingId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "status_booking",
                table: "Bookings",
                newName: "StatusBooking");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "Bookings",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "total_taxes_currency",
                table: "Bookings",
                newName: "TotalTaxes_Currency");

            migrationBuilder.RenameColumn(
                name: "total_taxes_amount",
                table: "Bookings",
                newName: "TotalTaxes_Amount");

            migrationBuilder.RenameColumn(
                name: "total_price_currency",
                table: "Bookings",
                newName: "TotalPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "total_price_amount",
                table: "Bookings",
                newName: "TotalPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "price_duration_currency",
                table: "Bookings",
                newName: "PriceDuration_Currency");

            migrationBuilder.RenameColumn(
                name: "price_duration_amount",
                table: "Bookings",
                newName: "PriceDuration_Amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_BookingId",
                table: "Guests",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
