using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SkyRoute_Travel_Platform_BackEnd.Enums;

namespace SkyRoute_Travel_Platform_BackEnd.Models
{
    public class Booking
    {
        public Guid Id { get; set; } //Used for database primary key
        public string BookingReference { get; set; } //Used for user-facing reference
        public Guid FlightId { get; set; }
        public string Provider { get; set; }
        public CabinClass CabinClass { get; set; } //What the passenger booked (Economy, Business, First)
        public int PassengerCount { get; set; }
        public decimal PerPassengerPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
    }
}

