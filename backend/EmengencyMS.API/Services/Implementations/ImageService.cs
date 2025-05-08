using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Concurrent;

namespace Services.Implementations;

internal class ImageService(IImageRepository imageRepository) : IImageService
{
    private readonly string _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

    public async Task<string> UploadImage(IFormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_uploadsFolder, fileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return fileName;
    }

    public async Task UploadImages(ICollection<IFormFile> files, string scheme, string host, int emergencyId)
    {
        var images = new ConcurrentBag<ImageDTO>();

        await Parallel.ForEachAsync(files, async (image, ct) =>
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(_uploadsFolder, fileName);
            var url = $"{scheme}://{host}/images/{fileName}";

            using var stream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(stream, ct);
            images.Add(new() { FileName = fileName, ImagePath = url });
        });

        var imagesEntities = images.Select(x => new Image()
        {
            FileName = x.FileName,
            ImagePath = x.ImagePath,
            EmergencyId = emergencyId
        }).ToList();

        await imageRepository.SaveImagesData(imagesEntities);
    }
}
