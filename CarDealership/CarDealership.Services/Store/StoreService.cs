using CarDealership.Data;
using CarDealership.Services.Dtos;
using CarDealership.Services.Store.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Services.Store;

public class StoreService(CarDealershipDbContext dbContext) : IStoreService
{
    private readonly CarDealershipDbContext _dbContext = dbContext;

    public async Task<IEnumerable<StoreAnalyticsResponse>> GetStoreAnalytics()
    {
        var analytics = await _dbContext
            .Database
            .SqlQuery<AnalyticsData>($"EXEC GetStoreAnalyticsData")
            .ToListAsync();

        return analytics
            .GroupBy(a => a.StoreId)
            .Select(g => new StoreAnalyticsResponse(
                StoreId: g.Key,
                StoreName: g.First().StoreName,
                MonthlyData: g.OrderBy(a => a.Year)
                    .ThenBy(a => a.Month)
                    .Select(a => new MonthlyData(
                        Year: a.Year,
                        Month: a.Month,
                        ClientCount: a.ClientCount,
                        OrderCount: a.OrderCount,
                        TotalPrice: a.TotalPrice,
                        AveragePrice: a.AveragePrice
                    ))
                    .ToList(),
                TotalData: new TotalData(
                    ClientCount: g.Sum(a => a.ClientCount),
                    OrderCount: g.Sum(a => a.OrderCount),
                    TotalPrice: g.Sum(a => a.TotalPrice),
                    AveragePrice: g.Sum(a => a.TotalPrice) / g.Sum(a => a.OrderCount)
                )
            ));
    }
}