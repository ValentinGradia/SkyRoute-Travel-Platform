using SkyRoute_Travel_Platform_BackEnd.Data;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

public class ArcticAirProvider(AppDbContext _dbContext) : BaseFlightProvider(_dbContext, "ArcticAir")
{
    public override decimal CalculatePrice(decimal basefare)
    {
        var finalPrice = basefare * 1.20m; // 10% discount
        return Math.Max(29.99m, finalPrice);
    }
}