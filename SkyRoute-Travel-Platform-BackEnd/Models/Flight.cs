using System;

namespace SkyRoute_Travel_Platform_BackEnd.Models
{
    public class Flight
    {
        public Guid Id { get; private set; }
        // public string Provider { get; set; }
        public string FlightNumber { get; private set; }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public DateTimeOffset Departure { get; private set; }
        public DateTimeOffset Arrival { get; private set; }
        public TimeSpan Duration { get; private set; }
        // public CabinClass CabinClass { get; set; }
        public decimal BaseFare { get; private set; }
    }
}

