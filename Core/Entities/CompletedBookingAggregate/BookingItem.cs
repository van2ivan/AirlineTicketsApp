using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.CompletedBookingAggregate
{
    public class BookingItem : BaseEntity 
    {
        public BookingItem()
        {
            
        }
        public BookingItem(FlightBooked flightBooked, decimal price)
        {
            FlightBooked = flightBooked;
            Price = price;
        }

        public FlightBooked FlightBooked { get; set; }
        public decimal Price { get; set; }
    }
}