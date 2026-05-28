using System;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.DTOs
{
    public class FlightSearchRequestDto
    {
        public string Origin { get; set; }
        public string CountryOrigin {get; set;}
        public string Destination { get; set; }
        public string CountryDestination {get; set;}
        public DateTimeOffset DepartureDate { get; set; }
        public int Passengers { get; set; }
        public CabinClass CabinClass { get; set; }
    }
}

