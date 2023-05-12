using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.CompletedBookingAggregate;
using Core.Interfaces;
using Infrastructure.Data;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CompletedBookingService : ICompletedBookingService
    {

        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly DbStoreContext _context;

        public CompletedBookingService(
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork,
            DbStoreContext context
        )
        {

            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<CompletedBooking> CreateCompletedBookingAsync(string buyerEmail, int luggageOptionId,
         string bookingId, Details passangerDetails)
        {
            var booking = await _bookingRepository.GetBookingAsync(bookingId);
            var items = new List<BookingItem>();
            foreach (var item in booking.Tickets)
            {
                var bookingItem = await GetFlightAsync(item.Id);// GetFlightAsync(item.Id) below! //.GetByIdAsync(item.Id);
                var flightBooked = new FlightBooked(
                    bookingItem.Id,
                    bookingItem.FlightNumber,
                    bookingItem.DepartureTime,
                    bookingItem.ArrivalTime,
                    bookingItem.ActualDepartureTime,
                    bookingItem.ActualArrivalTime,
                    bookingItem.Company.Name,
                    bookingItem.DepartureAirport.Name,
                    bookingItem.ArrivalAirport.Name
                );
                var completedBookingItem = new BookingItem(flightBooked, bookingItem.Price);
                items.Add(completedBookingItem);
            }
            var luggageOption = await _unitOfWork.Repository<LuggageOption>().GetByIdAsync(luggageOptionId);
            var subtotal = items.Sum(item => item.Price);

            var completedBooking = new CompletedBooking(
                items,
                buyerEmail,
                passangerDetails,
                luggageOption,
                subtotal
                );
            _unitOfWork.Repository<CompletedBooking>().Add(completedBooking); //add to tracking

            var result = await _unitOfWork.Complete(); // adding
            if (result <= 0) return null; //nothing has been saved to db

            await _bookingRepository.DeleteBookingAsync(bookingId);

            return completedBooking;
        }

        public async Task<CompletedBooking> GetCompletedBookingByIdAsync(int id, string passangerEmail)
        {
            var specification = new CompletedBookingsWithItemsAndCompletedBookingSpecifcation(id, passangerEmail);
            return await _unitOfWork.Repository<CompletedBooking>().GetEntityWithSpecification(specification);
            
        }

        public async Task<IReadOnlyList<CompletedBooking>> GetCompletedBookingForUserAsync(string passangerEmail)
        {
            var specification = new CompletedBookingsWithItemsAndCompletedBookingSpecifcation(passangerEmail);
            return await _unitOfWork.Repository<CompletedBooking>().ListAsync(specification);
        }

        public async Task<IReadOnlyList<LuggageOption>> GetLuggageOptionsAsync()
        {
            return await _unitOfWork.Repository<LuggageOption>().ListAllAsync();
        }
        public async Task<Flight> GetFlightAsync(int id)
        {
            return await _context.Flights
            .Include(x => x.ArrivalAirport)
            .Include(x => x.DepartureAirport)
            .Include(x => x.Plane)
            .Include(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}