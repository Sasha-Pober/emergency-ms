namespace Presentation.Contracts.Image;

internal class ImageResponse
{
    public int Id { get; set; }
    public int EmergencyId { get; set; }
    public string FileName { get; set; }
    public string ImagePath { get; set; }
}
