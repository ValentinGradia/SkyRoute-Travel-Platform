using System;

namespace SkyRoute_Travel_Platform_BackEnd.Models
{
    public class Passenger
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int DocumentNumber { get; private set; }
    }
}

