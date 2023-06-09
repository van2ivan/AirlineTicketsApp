﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DbStoreContext))]
    partial class DbStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longtitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeZone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Core.Entities.Booking", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LuggageOptionId")
                        .HasColumnType("int");

                    b.Property<decimal>("LuggagePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FlightCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.BookingItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompletedBookingId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompletedBookingId");

                    b.ToTable("BookingItems");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.CompletedBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("BookingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("LuggageOptionId")
                        .HasColumnType("int");

                    b.Property<string>("PassangerEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LuggageOptionId");

                    b.ToTable("CompletedBookings");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.LuggageOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("LuggageOptions");
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActualDepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartureAirportId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Core.Entities.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Core.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActualArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActualDepartureTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<string>("Plane")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.BookingItem", b =>
                {
                    b.HasOne("Core.Entities.CompletedBookingAggregate.CompletedBooking", null)
                        .WithMany("BookingItems")
                        .HasForeignKey("CompletedBookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Core.Entities.CompletedBookingAggregate.FlightBooked", "FlightBooked", b1 =>
                        {
                            b1.Property<int>("BookingItemId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("ActualArrivalTime")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ActualDepartureTime")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ArrivalAirport")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("ArrivalTime")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Company")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DepartureAirport")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("DepartureTime")
                                .HasColumnType("datetime2");

                            b1.Property<int>("FlightId")
                                .HasColumnType("int");

                            b1.Property<int>("FlightNumber")
                                .HasColumnType("int");

                            b1.HasKey("BookingItemId");

                            b1.ToTable("BookingItems");

                            b1.WithOwner()
                                .HasForeignKey("BookingItemId");
                        });

                    b.Navigation("FlightBooked");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.CompletedBooking", b =>
                {
                    b.HasOne("Core.Entities.CompletedBookingAggregate.LuggageOption", "LuggageOption")
                        .WithMany()
                        .HasForeignKey("LuggageOptionId");

                    b.OwnsOne("Core.Entities.CompletedBookingAggregate.Details", "BookingDetails", b1 =>
                        {
                            b1.Property<int>("CompletedBookingId")
                                .HasColumnType("int");

                            b1.Property<string>("Citizenship")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Passport")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompletedBookingId");

                            b1.ToTable("CompletedBookings");

                            b1.WithOwner()
                                .HasForeignKey("CompletedBookingId");
                        });

                    b.Navigation("BookingDetails");

                    b.Navigation("LuggageOption");
                });

            modelBuilder.Entity("Core.Entities.Flight", b =>
                {
                    b.HasOne("Core.Entities.Airport", "ArrivalAirport")
                        .WithMany("ArrivalFlights")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Company", "Company")
                        .WithMany("Flights")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Airport", "DepartureAirport")
                        .WithMany("DepartureFlights")
                        .HasForeignKey("DepartureAirportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ArrivalAirport");

                    b.Navigation("Company");

                    b.Navigation("DepartureAirport");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("Core.Entities.Plane", b =>
                {
                    b.HasOne("Core.Entities.Company", "Company")
                        .WithMany("Planes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Core.Entities.Ticket", b =>
                {
                    b.HasOne("Core.Entities.Booking", null)
                        .WithMany("Tickets")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("Core.Entities.Airport", b =>
                {
                    b.Navigation("ArrivalFlights");

                    b.Navigation("DepartureFlights");
                });

            modelBuilder.Entity("Core.Entities.Booking", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Core.Entities.Company", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Planes");
                });

            modelBuilder.Entity("Core.Entities.CompletedBookingAggregate.CompletedBooking", b =>
                {
                    b.Navigation("BookingItems");
                });

            modelBuilder.Entity("Core.Entities.Plane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
