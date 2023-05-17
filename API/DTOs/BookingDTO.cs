using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTOs
{
    public class BookingDTO
    {
        [Required]
        public string Id { get; set; }
        public List<TicketDTO> Tickets { get; set; } //= new List<TicketDTO>();
        public int? LuggageOptionId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal LuggagePrice { get; set; }

    }
}