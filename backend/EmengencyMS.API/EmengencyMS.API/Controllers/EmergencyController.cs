using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmengencyMS.API.Controllers
{
    [ApiController]
    public class EmergencyController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmergencies()
        {
            return Ok();
        }
    }
}
