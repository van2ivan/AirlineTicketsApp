using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
        {
            builder.HasOne(x => x.DepartureAirport).WithMany(x => x.DepartureFlights)
            .HasForeignKey(x => x.DepartureAirportId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ArrivalAirport).WithMany(x => x.ArrivalFlights)
            .HasForeignKey(x => x.ArrivalAirportId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Plane).WithMany(x => x.Flights).HasForeignKey(x => x.PlaneId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}