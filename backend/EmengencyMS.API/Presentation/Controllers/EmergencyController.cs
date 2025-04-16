using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    public class EmergencyController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmergencies()
        {
            return Ok(100);
        }
    }
}
