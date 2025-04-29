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
        public async Task<IActionResult> GetAllEmergencies(int page, int pageSize)
        {
            var result = await emergencyService.GetAllEmergencies(page, pageSize);

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

            var result = await emergencyService.CreateEmergency(emergency);
            return CreatedAtAction(nameof(GetAllEmergencies), new { id = emergency.Id }, emergency);
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetEmergenciesForPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await emergencyService.GetEmergenciesForPeriod(startDate, endDate);
            return Ok(result.Select(x => x.MapToResponse()));
        }
    }
}
