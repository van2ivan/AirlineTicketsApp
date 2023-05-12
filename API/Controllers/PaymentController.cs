using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [Authorize]
        [HttpPost("{bookingId}")]
        public async Task<ActionResult<Booking>> CreateOrUpdatePaymentIntent(string bookingId)
        {
            return await _paymentService.CreateOrUpdatePaymentIntent(bookingId);
        }
    }
}