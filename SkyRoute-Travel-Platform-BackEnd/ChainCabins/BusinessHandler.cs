using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.CabinHandler;

public class BusinessHandler : CabinHandler
{
    public override CabinResult Handle(Flight flight, CabinClass cabin, int passengerCount)
    {
        if (cabin == CabinClass.Business)
        {
            return new CabinResult
            {
                AvailableSeats = flight.BusinessSeats,
                Fare = flight.BusinessFare,
                IsAvailable = flight.BusinessSeats >= passengerCount
            };
        }

        return _nextHandler?.Handle(flight, cabin, passengerCount);
    }
}