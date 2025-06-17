using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IImageRepository
{
    Task DeleteImages(int id, List<string> imagesToDelete);
    Task<IEnumerable<Image>> GetImagesByEmergencyId(int id);
    Task SaveImageData(string fileName, string url);
    Task SaveImagesData(ICollection<Image> images);
}