using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Emergency;
using Presentation.Enums;
using Presentation.Mappings;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyController(IEmergencyService emergencyService) 
        : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EmergencyResponse>), 200)]
        public async Task<IActionResult> GetEmergencies(int page, int pageSize)
        {
            var result = await emergencyService.GetEmergencies(page, pageSize);

            return Ok(result.Select(x => x.MapToResponse()));
        }
    }
}
