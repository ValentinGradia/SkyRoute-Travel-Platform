using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.CabinHandler;

public class EconomyHandler : CabinHandler
{
    public override CabinResult Handle(Flight flight, CabinClass cabin, int passengerCount)
    {
        if (cabin != CabinClass.Economy)
        {
            return new CabinResult
            {
                AvailableSeats = flight.EconomySeats,
                Fare = flight.EconomyFare
            };
        }

        return _nextHandler.Handle(flight, cabin, passengerCount);
    }
}