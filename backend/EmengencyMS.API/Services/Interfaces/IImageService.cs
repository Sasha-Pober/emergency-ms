using Microsoft.AspNetCore.Http;

namespace Services.Interfaces;

public interface IImageService
{
    Task<string> UploadImage(IFormFile file);
    Task UploadImages(ICollection<IFormFile> files, string scheme, string host, int emergencyId);
}
