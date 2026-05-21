﻿using SkyRoute_Travel_Platform_BackEnd.DTOs;
 using SkyRoute_Travel_Platform_BackEnd.Enums;
 using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

public interface IFlightProvider
{
    Task<IEnumerable<FlightSearchResponseDto>> SearchFlights(FlightSearchRequestDto request);
    
    decimal CalculatePrice(decimal basefare);
    
}