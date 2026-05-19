using System;
using System.Collections.Generic;

namespace SkyRoute_Travel_Platform_BackEnd.Models
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public string BookingReference { get; private set; }
        public Guid FlightId { get; private set; }
        // public string Provider { get; set; }
        // public CabinClass CabinClass { get; set; }
        public int PassengerCount { get; private set; }
        public decimal PerPassengerPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }

        public List<Passenger> Passengers { get; private set; } = new();
    }
}

