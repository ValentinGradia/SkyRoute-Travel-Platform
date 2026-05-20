using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.CabinHandler;

public class FirstClassHandler : CabinHandler
{
    public override CabinResult Handle(Flight flight, CabinClass cabin, int passengerCount)
    {
        if (cabin == CabinClass.First)
        {
            return new CabinResult
            {
                AvailableSeats = flight.FirstClassSeats,
                Fare = flight.FirstClassFare,
                IsAvailable = flight.FirstClassSeats >= passengerCount
            };
        }

        return _nextHandler?.Handle(flight, cabin, passengerCount);
    }
}