using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.CompletedBookingAggregate;

namespace Core.Specifications
{
    public class CompletedBookingsWithItemsAndCompletedBookingSpecifcation : BaseSpecification<CompletedBooking>
    {
        public CompletedBookingsWithItemsAndCompletedBookingSpecifcation(string email) 
        : base(cb => cb.PassangerEmail == email)
        {
            AddInclude(x => x.BookingItems);
            AddInclude(x => x.LuggageOption);
            AddOrderByDescending(x => x.BookingDate);
        }
        public CompletedBookingsWithItemsAndCompletedBookingSpecifcation(int id, string email)
         : base(x => x.Id == id && x.PassangerEmail == email)
        {
            AddInclude(x => x.BookingItems);
            AddInclude(x => x.LuggageOption);
        }
    }
}