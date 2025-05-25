using Microsoft.AspNetCore.Mvc;
using Presentation.Mappings;
using Services.Interfaces;

namespace Presentation.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IAnalyticsService analyticsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllRegionsAnalytics()
    {
        var result = await analyticsService.GetAnalyticsResults();

        if (result == null)
        {
            return NotFound("No analytics data found.");
        }

        return Ok(result.MapToResponse());
    }
}
