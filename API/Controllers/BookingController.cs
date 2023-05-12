using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BookingController : BaseApiController
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public BookingController(IBookingRepository bookingRspotiory, IMapper mapper)
        {
            _bookingRepository = bookingRspotiory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Booking>> GetBookingId(string id)
        {
            var booking = await _bookingRepository.GetBookingAsync(id);
            return Ok(booking ?? new Booking(id));
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> UpdateBooking(BookingDTO booking)
        {
            var bookingDto = _mapper.Map<BookingDTO, Booking>(booking);
            var updatedBooking = await _bookingRepository.UpdateBookingAsync(bookingDto);
            return Ok(updatedBooking);
        }

        [HttpDelete]
        public async Task DeleteBookingIAsync(string id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}