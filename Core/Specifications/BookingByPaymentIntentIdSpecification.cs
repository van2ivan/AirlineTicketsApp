using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.CompletedBookingAggregate;

namespace Core.Specifications
{
    public class BookingByPaymentIntentIdSpecification : BaseSpecification<CompletedBooking>
    {
        public BookingByPaymentIntentIdSpecification(string paymentIntentId)
        :base(x => x.PaymentIntentId == paymentIntentId)
        {

        }
    }
}