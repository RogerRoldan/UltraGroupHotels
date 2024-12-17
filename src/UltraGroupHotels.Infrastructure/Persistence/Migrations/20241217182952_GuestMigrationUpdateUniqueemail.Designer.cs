﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UltraGroupHotels.Infrastructure.Persistence;

#nullable disable

namespace UltraGroupHotels.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241217182952_GuestMigrationUpdateUniqueemail")]
    partial class GuestMigrationUpdateUniqueemail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UltraGroupHotels.Domain.Bookings.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid")
                        .HasColumnName("room_id");

                    b.Property<int>("StatusBooking")
                        .HasColumnType("integer")
                        .HasColumnName("status_booking");

                    b.Property<decimal>("TaxesPercentage")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("taxes_percentage");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Guest.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uuid")
                        .HasColumnName("booking_id");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("document_number");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type_document");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("Email")
                        .HasDatabaseName("IX_guests_email");

                    b.ToTable("guests", (string)null);
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Hotels.Hotel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("hotels", (string)null);
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uuid")
                        .HasColumnName("hotel_id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("integer")
                        .HasColumnName("room_number");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("room_type");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnName("taxes");

                    b.HasKey("Id");

                    b.HasIndex("HotelId", "RoomNumber")
                        .IsUnique()
                        .HasDatabaseName("IX_Rooms_HotelId_RoomNumber");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("full_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Users_Email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Bookings.Booking", b =>
                {
                    b.OwnsOne("UltraGroupHotels.Domain.CommonValueObjects.Money", "PriceDuration", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("price_duration_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_duration_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("UltraGroupHotels.Domain.CommonValueObjects.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("total_price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("total_price_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("UltraGroupHotels.Domain.CommonValueObjects.Money", "TotalTaxes", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("total_taxes_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("total_taxes_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("UltraGroupHotels.Domain.Bookings.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("date")
                                .HasColumnName("end_date");

                            b1.Property<DateOnly>("StartDate")
                                .HasColumnType("date")
                                .HasColumnName("start_date");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("UltraGroupHotels.Domain.Bookings.EmergencyContact", "EmergencyContact", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)")
                                .HasColumnName("emergency_contact_full_name");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("emergency_contact_phone_number");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("EmergencyContact")
                        .IsRequired();

                    b.Navigation("PriceDuration")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();

                    b.Navigation("TotalTaxes")
                        .IsRequired();
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Guest.Guest", b =>
                {
                    b.HasOne("UltraGroupHotels.Domain.Bookings.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Hotels.Hotel", b =>
                {
                    b.OwnsOne("UltraGroupHotels.Domain.CommonValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("HotelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("address_street");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)")
                                .HasColumnName("address_zip_code");

                            b1.HasKey("HotelId");

                            b1.ToTable("hotels");

                            b1.WithOwner()
                                .HasForeignKey("HotelId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("UltraGroupHotels.Domain.Rooms.Room", b =>
                {
                    b.HasOne("UltraGroupHotels.Domain.Hotels.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("UltraGroupHotels.Domain.Rooms.QuantityGuests", "QuantityGuests", b1 =>
                        {
                            b1.Property<Guid>("RoomId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Adults")
                                .HasColumnType("integer")
                                .HasColumnName("quantity_guests_adults");

                            b1.Property<int>("Children")
                                .HasColumnType("integer")
                                .HasColumnName("quantity_guests_children");

                            b1.HasKey("RoomId");

                            b1.ToTable("rooms");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.OwnsOne("UltraGroupHotels.Domain.CommonValueObjects.Money", "BaseCost", b1 =>
                        {
                            b1.Property<Guid>("RoomId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("base_cost_currency");

                            b1.HasKey("RoomId");

                            b1.ToTable("rooms");

                            b1.WithOwner()
                                .HasForeignKey("RoomId");
                        });

                    b.Navigation("BaseCost")
                        .IsRequired();

                    b.Navigation("QuantityGuests")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
