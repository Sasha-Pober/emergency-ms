using Domain.Entities;
using System.Data;

namespace Infrastructure;

internal static class DatabaseMapper
{
    internal static DataTable ToEmergencyDataTable(this Emergency emergency)
    {
        var table = new DataTable();
        table.Columns.Add("Title", typeof(string));
        table.Columns.Add("EmergencyTypeId", typeof(int));
        table.Columns.Add("EmergencySubTypeId", typeof(int));
        table.Columns.Add("AccidentDate", typeof(DateTime));
        table.Columns.Add("DateEntered", typeof(DateTime));
        table.Columns.Add("Severity", typeof(int));
        table.Columns.Add("Casualties", typeof(int));
        table.Columns.Add("Injured", typeof(int));
        table.Columns.Add("EconomicLoss", typeof(decimal));
        table.Columns.Add("Duration", typeof(double));
        table.Columns.Add("Description", typeof(string));

        table.Rows.Add(
            emergency.Title,
            emergency.EmergencyTypeId,
            emergency.EmergencySubTypeId,
            emergency.AccidentDate,
            emergency.DateEntered,
            emergency.Severity,
            emergency.Casualties,
            emergency.Injured,
            emergency.EconomicLoss,
            emergency.Duration,
            emergency.Description
        );

        return table;
    }

    internal static DataTable ToLocationDataTable(this Location location, Street street)
    {
        var table = new DataTable();
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("RegionTypeId", typeof(int));
        table.Columns.Add("Latitude", typeof(double));
        table.Columns.Add("Longitude", typeof(double));
        table.Columns.Add("StreetName", typeof(string));
        table.Columns.Add("HouseNr", typeof(int));

        table.Rows.Add(
            location.Name,
            location.RegionTypeId,
            location.Latitude,
            location.Longitude,
            street.StreetName,
            street.HouseNr
        );
        return table;
    }

    internal static DataTable ToSourceDataTable(this Source source)
    {
        var table = new DataTable();
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("Url", typeof(string));
        table.Columns.Add("SourceTypeId", typeof(string));

        table.Rows.Add(
            source.Name,
            source.Url,
            source.SourceTypeId
        );
        return table;
    }

    internal static DataTable ToImageDataTable(this ICollection<Image> image)
    {
        var table = new DataTable();
        table.Columns.Add("EmergencyId", typeof(int));
        table.Columns.Add("ImagePath", typeof(string));
        table.Columns.Add("FileName", typeof(string));

        foreach (var item in image)
        {
            table.Rows.Add(
                item.EmergencyId,
                item.ImagePath,
                item.FileName
            );
        }
        return table;
    }

}
