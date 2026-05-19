using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Services;

public class BookingService(AppDbContext _dbContext)
{
    public async Task<string> CreateBookingAsync([FromBody] BookingRequestDto request)
    {
        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            BookingReference = "SKY-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper(),
            Provider = request.Provider,
            CabinClass = request.CabinClass,
            TotalPrice = request.FinalPrice,
            PassengerCount = request.PassengerCount,
            PerPassengerPrice = request.FinalPrice / request.PassengerCount,
            FullName = request.FullName,
            Email = request.Email,
            DocumentNumber = request.DocumentNumber,
            CreatedAt = DateTimeOffset.UtcNow
            
        };

        await _dbContext.Bookings.AddAsync(booking);
        return booking.BookingReference;
    }
}