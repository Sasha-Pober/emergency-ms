using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Emergency;
using Presentation.Mappings;
using Services.DTO;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/emergencies")]
    public class EmergencyController(IEmergencyService emergencyService, IImageService imageService) 
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
        [Authorize(AuthenticationSchemes = "Identity.Bearer", Roles = "Admin,Manager")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEmergency([FromForm] CreateEmergency request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var emergency = request.MapToDTO();

            var emergencyId = await emergencyService.CreateEmergency(emergency);

            if (request.Images != null && request.Images.Count > 0 && emergencyId != 0)
            {
                await imageService.UploadImages(request.Images, Request.Scheme, Request.Host.Value, emergencyId);
            }
            return CreatedAtAction(nameof(GetAllEmergencies), new { id = emergency.Id }, emergency);
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetEmergenciesForPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await emergencyService.GetEmergenciesForPeriod(startDate, endDate);
            return Ok(result.Select(x => x.MapToResponse()));
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetEmergencyTypes()
        {
            var result = await emergencyService.GetEmergencyTypes();
            return Ok(result.Select(x => x.MapToResponse()));
        }

        [HttpGet("subtypes")]
        public async Task<IActionResult> GetEmergencySubTypes()
        {
            var result = await emergencyService.GetEmergencySubTypes();
            return Ok(result.Select(x => x.MapToResponse()));
        }
    }
}
