using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IImageRepository
{
    Task SaveImageData(string fileName, string url);
    Task SaveImagesData(ICollection<Image> images);
}