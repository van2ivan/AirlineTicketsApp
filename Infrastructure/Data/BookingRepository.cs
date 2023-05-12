using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System.Text.Json;


namespace Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDatabase _database;
        public BookingRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBookingAsync(string bookingId)
        {
            return await _database.KeyDeleteAsync(bookingId);
        }

        public async Task<Booking> GetBookingAsync(string bookingId)
        {
            var data = await _database.StringGetAsync(bookingId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Booking>(data);
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            var created = await _database.StringSetAsync(booking.Id,
             JsonSerializer.Serialize(booking), TimeSpan.FromDays(30));

            if (!created) return null;
            return await GetBookingAsync(booking.Id);
        }
    }
}