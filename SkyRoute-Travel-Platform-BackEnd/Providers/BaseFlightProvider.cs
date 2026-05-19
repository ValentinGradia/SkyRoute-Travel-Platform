using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

//Abstract base class for flight providers, implementing common search logic and leaving price calculation to derived classes. Besides, in the future we can add more
//providers by simply inheriting from this base class and implementing the CalculatePrice method according to their specific pricing strategies. 
public abstract class BaseFlightProvider(AppDbContext _dbContext, string _providerName) : IFlightProvider
{
    public abstract decimal CalculatePrice(decimal basefare);

    public async Task<IEnumerable<Flight>> SearchFlights(FlightSearchRequestDto request)
    {
        IEnumerable<Flight> flights = await _dbContext.Flights
            .Where(f => f.Provider == _providerName && f.Origin == request.Origin && f.Destination == request.Destination && f.Departure.Date == request.DepartureDate.Date)
            .ToListAsync();
        
        return flights;
    }
}
