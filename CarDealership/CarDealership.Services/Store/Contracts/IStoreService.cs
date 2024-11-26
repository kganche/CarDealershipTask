using CarDealership.Services.Dtos;

namespace CarDealership.Services.Store.Contracts;

public interface IStoreService
{
    Task<IEnumerable<StoreAnalyticsResponse>> GetStoreAnalytics();
}