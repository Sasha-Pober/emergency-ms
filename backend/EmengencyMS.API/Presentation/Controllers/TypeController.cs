using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers;

[ApiController]
[Route("api/types")]
public class TypeController(ITypeService typeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTypes()
    {
        var types = await typeService.GetAllTypesAsync();
        return Ok(types);
    }
}
