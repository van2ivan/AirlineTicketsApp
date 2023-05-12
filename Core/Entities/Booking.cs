using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Booking
    {
        public Booking()
        {
        }
        public Booking(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public int? LuggageOptionId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal LuggagePrice { get; set; }
    }
}