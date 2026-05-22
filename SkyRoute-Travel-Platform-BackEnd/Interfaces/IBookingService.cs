using Microsoft.AspNetCore.Mvc;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Interfaces;

public interface IBookingService
{
    Task<string> CreateBookingAsync([FromBody] BookingRequestDto request);

    Task UpdateSeats(string flightNumber, CabinClass cabinClass, int passengers);

    Task<Booking> GetBookingByReferenceAsync(string bookingReference);
}