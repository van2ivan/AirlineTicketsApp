using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities.CompletedBookingAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class LuggageOptionConfiguration : IEntityTypeConfiguration<LuggageOption>
    {
        public void Configure(EntityTypeBuilder<LuggageOption> builder)
        {
            builder.Property(d => d.Price)
            .HasColumnType("decimal(18,2)");
        }
    }
}