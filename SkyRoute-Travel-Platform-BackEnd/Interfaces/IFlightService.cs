using SkyRoute_Travel_Platform_BackEnd.DTOs;

namespace SkyRoute_Travel_Platform_BackEnd.Interfaces;

public interface IFlightService
{
    Task<List<FlightSearchResponseDto>> SearchFlights(FlightSearchRequestDto request);
}