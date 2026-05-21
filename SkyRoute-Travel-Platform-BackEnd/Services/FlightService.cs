using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Providers;

namespace SkyRoute_Travel_Platform_BackEnd.Services;

public class FlightService(IEnumerable<IFlightProvider> flightProviders) 
{
    public async Task<List<FlightSearchResponseDto>> SearchFlights(FlightSearchRequestDto request)
    {
        var allFlights = new List<FlightSearchResponseDto>();

        foreach (var provider in flightProviders)
        {
            IEnumerable<FlightSearchResponseDto> flights = await provider.SearchFlights(request);
            allFlights.AddRange(flights);
        }

        return allFlights;
    }
    
    // public async Task UpdateSeats(string flightNumber, CabinClass cabinClass, int seatsToBook)
    // {
    //    await flightProviders(flightNumber, cabinClass, seatsToBook);
    // }
    
}