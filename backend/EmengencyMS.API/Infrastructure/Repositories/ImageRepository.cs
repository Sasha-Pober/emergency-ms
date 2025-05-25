using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

internal class ImageRepository(SqlConnection connection) : IImageRepository
{
    public Task SaveImagesData(ICollection<Image> images)
    {
        var imageDataTable = images.ToImageDataTable();
        return connection.ExecuteAsync(
            "[dbo].[SaveImagesData]",
            new
            {
                Images = imageDataTable.AsTableValuedParameter("dbo.ImageUDT"),
            },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }

    public async Task SaveImageData(string fileName, string url)
    {
        var query = "[dbo].[SaveImageData]";
        var parameters = new { FileName = fileName, Url = url };
        await connection.ExecuteAsync(query, parameters);
    }
}
