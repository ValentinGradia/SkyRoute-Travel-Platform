using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

public interface IFlightProvider
{
    decimal CalculatePrice(Booking booking);
}