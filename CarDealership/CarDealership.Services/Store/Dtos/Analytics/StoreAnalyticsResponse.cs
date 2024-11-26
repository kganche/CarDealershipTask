namespace CarDealership.Services.Dtos;

public record StoreAnalyticsResponse(
    int StoreId,
    string StoreName,
    List<MonthlyData> MonthlyData,
    TotalData TotalData
    );