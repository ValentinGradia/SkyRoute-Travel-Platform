using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;
using SkyRoute_Travel_Platform_BackEnd.Providers;

namespace SkyRoute_Travel_Platform_BackEnd.Services;

public class FlightService(IFlightProvider flightProvider) 
{
    public async Task<List<Flight>> SearchFlights(FlightSearchRequestDto request)
    {
        IEnumerable<Flight> flights = await flightProvider.SearchFlights(request);
        return flights.ToList();

    }
}