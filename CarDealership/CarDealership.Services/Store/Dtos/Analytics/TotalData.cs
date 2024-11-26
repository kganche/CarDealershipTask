namespace CarDealership.Services.Dtos;

public record TotalData(
    int ClientCount,
    int OrderCount,
    decimal TotalPrice,
    decimal AveragePrice
    );