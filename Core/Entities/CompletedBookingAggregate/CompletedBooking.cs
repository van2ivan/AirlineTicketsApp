using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.CompletedBookingAggregate
{
    public class CompletedBooking : BaseEntity
    {
        public CompletedBooking()
        {

        }
        public CompletedBooking(IReadOnlyList<BookingItem> bookingItems, string passangerEmail, Details bookingDetails, LuggageOption luggageOption, decimal subtotal)
        {
            PassangerEmail = passangerEmail;
            BookingDetails = bookingDetails;
            LuggageOption = luggageOption;
            BookingItems = bookingItems;
            Subtotal = subtotal;
        }

        public string PassangerEmail { get; set; }
        public DateTimeOffset BookingDate { get; set; } = DateTimeOffset.Now;
        public Details BookingDetails { get; set; }
        public LuggageOption LuggageOption { get; set; }
        public IReadOnlyList<BookingItem> BookingItems { get; set; }
        public decimal Subtotal { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return Subtotal + LuggageOption.Price;
        }

    }
}