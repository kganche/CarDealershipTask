using CarDealership.Services.Store.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Api.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IStoreService storeService) : ControllerBase
{
    private readonly IStoreService _storeService = storeService;

    [HttpGet("store-analytics")]
    public async Task<IActionResult> GetStoreAnalytics()
    {
        var result = await _storeService.GetStoreAnalytics();
        return Ok(result);
    }
}