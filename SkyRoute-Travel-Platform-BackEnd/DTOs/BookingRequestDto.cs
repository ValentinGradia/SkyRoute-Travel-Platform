using System;
using System.Collections.Generic;
using SkyRoute_Travel_Platform_BackEnd.Enums;

namespace SkyRoute_Travel_Platform_BackEnd.DTOs
{
    public class BookingRequestDto
    {
        public Guid FlightId { get; set; }
        public string Provider { get; set; }
        public int PassengerCount { get; set; }
        public CabinClass CabinClass { get; set; }
        public decimal FinalPrice { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
    }

}
