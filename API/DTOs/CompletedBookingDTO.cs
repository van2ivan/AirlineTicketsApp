using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CompletedBookingDTO
    {
        public string BookingId { get; set; }
        public int LuggageOptionId { get; set; }
        public DetailsDTO BookingDetails { get; set; }

    }
}