using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.CompletedBookingAggregate;

namespace API.DTOs
{
    public class CompletedBookingToReturnDTO
    {
        public int Id { get; set; }
        public string PassangerEmail { get; set; }
        public DateTimeOffset BookingDate { get; set; }
        public Details BookingDetails { get; set; }
        public string LuggageOption { get; set; }
        public decimal LuggagePrice { get; set; }
        public IReadOnlyList<BookingItemDTO> BookingItems { get; set; }
        public decimal Subtotal { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
    }
}