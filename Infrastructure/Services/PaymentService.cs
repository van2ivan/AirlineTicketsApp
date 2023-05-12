using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.CompletedBookingAggregate;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public PaymentService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork,
        IConfiguration config)
        {
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _config = config;

        }

        public async Task<Booking> CreateOrUpdatePaymentIntent(string bookingId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var booking = await _bookingRepository.GetBookingAsync(bookingId);
            var luggagePrice = 0m;

            if (booking.LuggageOptionId.HasValue)
            {
                var luggageOption = await _unitOfWork.Repository<LuggageOption>()
                .GetByIdAsync((int)booking.LuggageOptionId);

                luggagePrice = luggageOption.Price;
            }
            foreach (var item in booking.Tickets)
            {
                var bookingItem = await _unitOfWork.Repository<Flight>().GetByIdAsync(item.Id);
                if (item.Price != bookingItem.Price)
                {
                    item.Price = bookingItem.Price;
                }
            }
            var service = new PaymentIntentService();
            PaymentIntent intent;
            if (string.IsNullOrEmpty(booking.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)booking.Tickets.Sum(x => (x.Price * 100)) + (long)luggagePrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string>{"card"}
                };
                intent = await service.CreateAsync(options);
                booking.PaymentIntentId = intent.Id;
                booking.ClientSecret = intent.ClientSecret;

            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)booking.Tickets.Sum(x => (x.Price * 100)) + (long)luggagePrice * 100
                };
                await service.UpdateAsync(booking.PaymentIntentId, options);
            }
            await _bookingRepository.UpdateBookingAsync(booking);
            return booking;
        }
    }
}