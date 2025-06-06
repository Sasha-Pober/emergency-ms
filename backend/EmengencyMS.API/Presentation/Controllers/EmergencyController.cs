﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Emergency;
using Presentation.Mappings;
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

        [HttpGet("unapproved")]
        [ProducesResponseType(typeof(IEnumerable<EmergencyResponse>), 200)]
        public async Task<IActionResult> GetAllEmergencies()
        {
            var result = await emergencyService.GetUnapprovedEmergencies();

            return Ok(result.Select(x => x.MapToResponse()));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateEmergency([FromForm] CreateEmergency request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var emergency = request.MapToDTO(true);

            var emergencyId = await emergencyService.CreateEmergency(emergency);

            if (request.Images != null && request.Images.Count > 0 && emergencyId != 0)
            {
                await imageService.UploadImages(request.Images, Request.Scheme, Request.Host.Value, emergencyId);
            }
            return CreatedAtAction(nameof(GetAllEmergencies), new { id = emergency.Id }, emergency);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmergency(int id)
        {
            await emergencyService.DeleteEmergency(id);
            return NoContent();
        }

        [HttpPost("suggest")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SuggestEmergency([FromForm] CreateEmergency request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }
            var emergency = request.MapToDTO();

            var emergencyId = await emergencyService.CreateEmergency(emergency);

            if (request.Images != null && request.Images.Count > 0 && emergencyId > 0)
            {
                await imageService.UploadImages(request.Images, Request.Scheme, Request.Host.Value, emergencyId);
            }
            else if (emergencyId == -1)
            {
                throw new ArgumentException("Error during saving record");
            }

            return CreatedAtAction(nameof(GetAllEmergencies), new { id = emergencyId }, emergency);
        }

        [HttpPost("{id:int}/approve")]
        public async Task<IActionResult> ApproveEmergency(int id)
        {
            await emergencyService.ApproveEmergency(id);

            return Ok(new { Id = id });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(EmergencyResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmergencyById(int id)
        {
            var emergency = await emergencyService.GetEmergencyById(id);
            if (emergency == null)
            {
                return NotFound();
            }
            return Ok(emergency.MapToResponseWithImages());
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetEmergenciesForPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await emergencyService.GetEmergenciesForPeriod(startDate, endDate);
            return Ok(result.Select(x => x.MapToResponse()));
        }
    }
}
