using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Enums;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.CabinHandler;

public abstract class CabinHandler
{
    protected CabinHandler _nextHandler;

    public CabinHandler SetNextHandler(CabinHandler nextHandler)
    {
        this._nextHandler = nextHandler;
        return nextHandler;
    }
    
    public abstract CabinResult Handle(Flight flight, CabinClass cabin, int passengerCount);
    
    
}