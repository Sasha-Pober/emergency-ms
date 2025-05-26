using Microsoft.AspNetCore.Mvc;
using Presentation.Mappings;
using Services.Interfaces;

namespace Presentation.Controllers;

[ApiController]
[Route("api")]
public class TypeController(ITypeService typeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTypes()
    {
        var types = await typeService.GetAllTypesAsync();
        return Ok(types);
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetEmergencyTypes()
    {
        var result = await typeService.GetEmergencyTypes();
        return Ok(result.Select(x => x.MapToResponse()));
    }

    [HttpGet("subtypes")]
    public async Task<IActionResult> GetEmergencySubTypes()
    {
        var result = await typeService.GetEmergencySubTypes();
        return Ok(result.Select(x => x.MapToResponse()));
    }
}
