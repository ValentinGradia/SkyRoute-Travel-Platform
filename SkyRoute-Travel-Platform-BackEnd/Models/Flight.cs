using System;
using SkyRoute_Travel_Platform_BackEnd.Enums;

namespace SkyRoute_Travel_Platform_BackEnd.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string Provider { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public TimeSpan Duration { get; set; }
    
        public decimal EconomyFare { get; set; }
        public decimal BusinessFare { get; set; }
        public decimal FirstClassFare { get; set; }
    
        public int EconomySeats { get; set; }
        public int BusinessSeats { get; set; }
        public int FirstClassSeats { get; set; }
    }
}

