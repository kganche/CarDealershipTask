namespace CarDealership.Services.Dtos;

public record AnalyticsData(
    int StoreId,
    string StoreName,
    int ClientCount,
    int OrderCount,
    decimal TotalPrice,
    decimal AveragePrice,
    int Year,
    int Month
    );