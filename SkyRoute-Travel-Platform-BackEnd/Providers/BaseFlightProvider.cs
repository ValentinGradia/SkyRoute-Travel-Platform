using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.CabinHandler;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

//Abstract base class for flight providers, implementing common search logic and leaving price calculation to derived classes. Besides, in the future we can add more
//providers by simply inheriting from this base class and implementing the CalculatePrice method according to their specific pricing strategies. 
public abstract class BaseFlightProvider(AppDbContext _dbContext, string _providerName) : IFlightProvider
{
    public abstract decimal CalculatePrice(decimal basefare);

    public async Task<IEnumerable<FlightSearchResponseDto>> SearchFlights(FlightSearchRequestDto request)
    {
        EconomyHandler economyHandler = new EconomyHandler();
        economyHandler.SetNextHandler(new BusinessHandler()).SetNextHandler(new FirstClassHandler());
        
        IEnumerable<Flight> flights = await _dbContext.Flights
            .Where(f => f.Provider == _providerName && f.Origin == request.Origin && f.Destination == request.Destination && f.Departure.Date == request.DepartureDate.Date)
            .ToListAsync();
        
        // Filter and map using the chain responsability pattern for cabin availability and pricing
        return flights
            .Select(f => new
            {
                Flight = f,
                CabinResult = economyHandler.Handle(f, request.CabinClass, request.Passengers)
            })
            .Where(x => x.CabinResult?.IsAvailable ?? false)
            .Select(x => new FlightSearchResponseDto
            {
                Id = x.Flight.Id,
                FlightNumber = x.Flight.FlightNumber,
                Origin = x.Flight.Origin,
                Destination = x.Flight.Destination,
                Departure = x.Flight.Departure,
                Arrival = x.Flight.Arrival,
                Duration = x.Flight.Duration,
                Provider = x.Flight.Provider,

                // Only the cabin that user requested
                CabinClass = request.CabinClass.ToString(),
                AvailableSeats = x.CabinResult.AvailableSeats,
                Fare = x.CabinResult.Fare
            });
    }
}
