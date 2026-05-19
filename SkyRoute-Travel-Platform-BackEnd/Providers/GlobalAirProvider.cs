using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

public class GlobalAirProvider(AppDbContext _dbContext) : BaseFlightProvider(_dbContext, "GlobalAir")
{
    public override decimal CalculatePrice(decimal basefare)
    {
        return Math.Round(basefare * 1.15m, 2);
    }
}