using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Interfaces;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Providers;

namespace SkyRoute_Travel_Platform_BackEnd.Services;

public class BookingService(AppDbContext _dbContext) : IBookingService
{
    public async Task<string> CreateBookingAsync([FromBody] BookingRequestDto request)
    {

        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            FlightNumber = request.FlightNumber,
            BookingReference = "SKY-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper(),
            Provider = request.Provider,
            CabinClass = request.CabinClass,
            TotalPrice = request.FinalPrice,
            PassengerCount = request.PassengerCount,
            PerPassengerPrice = request.PricePerPassenger,
            FullName = request.FullName,
            Email = request.Email,
            DocumentNumber = request.DocumentNumber,
            CreatedAt = DateTimeOffset.UtcNow
            
        };
        
        await this.UpdateSeats(request.FlightNumber, request.CabinClass, request.PassengerCount);
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.SaveChangesAsync();
        return booking.BookingReference;
    }
    
    public async Task UpdateSeats(string flightNumber, CabinClass cabinClass, int passengers)
    {
        var flight = await _dbContext.Flights
            .FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);
        
        switch (cabinClass)
        {
            case CabinClass.Economy:
                flight!.EconomySeats -= passengers;
                break;
            case CabinClass.Business:
                flight!.BusinessSeats -= passengers;
                break;
            case CabinClass.FirstClass:
                flight!.FirstClassSeats -= passengers;
                break;
        }
    }
    
    public async Task<Booking> GetBookingByReferenceAsync(string bookingReference)
    {
        return await _dbContext.Bookings.FirstOrDefaultAsync(b => b.BookingReference == bookingReference);
    }
}