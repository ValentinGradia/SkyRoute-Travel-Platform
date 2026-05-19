using Microsoft.EntityFrameworkCore;
using SkyRoute_Travel_Platform_BackEnd.Data;
using SkyRoute_Travel_Platform_BackEnd.DTOs;
using SkyRoute_Travel_Platform_BackEnd.Models;

namespace SkyRoute_Travel_Platform_BackEnd.Providers;

public class BudgetWindsProvider(AppDbContext _dbContext) : BaseFlightProvider(_dbContext, "BudgetWings")
{
    public override decimal CalculatePrice(decimal basefare)
    {
        var discountedPrice = basefare * 0.90m; // 10% discount
        return Math.Max(29.99m, discountedPrice); //29.99 minimum price
    }
}