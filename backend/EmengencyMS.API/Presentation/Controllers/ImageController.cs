using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Presentation.Controllers;

[ApiController]
[Route("api/images")]
public class ImageController(IImageService imageService) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadPhoto(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File was not uploaded.");

        var fileName = await imageService.UploadImage(file);

        var url = $"{Request.Scheme}://{Request.Host}/images/{fileName}";
        return Ok(new { fileName, url });
    }

}
