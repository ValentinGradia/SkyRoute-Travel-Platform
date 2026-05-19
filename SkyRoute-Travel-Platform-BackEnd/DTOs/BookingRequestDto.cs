using System;
using System.Collections.Generic;
using SkyRoute_Travel_Platform_BackEnd.Enums;

namespace SkyRoute_Travel_Platform_BackEnd.DTOs
{
    public class BookingRequestDto
    {
        public Guid FlightId { get; set; }
        public string Provider { get; set; }
        public CabinClass CabinClass { get; set; }
        public List<PassengerDTO> Passengers { get; set; }
        public string ContactEmail { get; set; }
    }

}
