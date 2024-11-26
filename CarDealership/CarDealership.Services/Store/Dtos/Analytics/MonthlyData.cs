namespace CarDealership.Services.Dtos;

public record MonthlyData(
    int Year,
    int Month,
    int ClientCount,
    int OrderCount,
    decimal TotalPrice,
    decimal AveragePrice
    );