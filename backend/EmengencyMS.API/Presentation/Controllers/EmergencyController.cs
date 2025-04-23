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

        [HttpPost]
        public async Task<IActionResult> CreateEmergency([FromBody] CreateEmergency request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var emergency = request.MapToDTO();

            await emergencyService.CreateEmergency(emergency);
            return CreatedAtAction(nameof(GetEmergencies), new { id = emergency.Id }, emergency);
        }
    }
}
