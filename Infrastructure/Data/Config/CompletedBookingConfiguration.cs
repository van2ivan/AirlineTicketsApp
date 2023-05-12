using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities.CompletedBookingAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CompletedBookingConfiguration : IEntityTypeConfiguration<CompletedBooking>
    {
        public void Configure(EntityTypeBuilder<CompletedBooking> builder)
        {
            builder.OwnsOne(o => o.BookingDetails, a =>
            {
                a.WithOwner();
            });
            builder.Property(s => s.Status)
            .HasConversion(
                o => o.ToString(),
                o => (BookingStatus)Enum.Parse(typeof(BookingStatus), o)
            );
            builder.HasMany(o => o.BookingItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}