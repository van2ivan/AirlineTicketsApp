using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.CompletedBookingAggregate;

namespace Core.Interfaces
{
    public interface ICompletedBookingService
    {
        Task<CompletedBooking> CreateCompletedBookingAsync(string buyerEmail, int luggageOption, string bookingId,
        Details passangerDetails);
        Task<IReadOnlyList<CompletedBooking>> GetCompletedBookingForUserAsync(string buyerEmail);
        Task<CompletedBooking> GetCompletedBookingByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<LuggageOption>> GetLuggageOptionsAsync();
    }
}