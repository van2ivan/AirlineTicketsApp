using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Entities.CompletedBookingAggregate;
using System.Reflection;

namespace Infrastructure.Data
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CompletedBooking> CompletedBookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<LuggageOption> LuggageOptions { get; set; }

    }
}