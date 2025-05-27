using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

internal class EmergencyRepository(SqlConnection connection) : IEmergencyRepository
{

    public Task<int> CreateEmergency(Emergency emergencyEntity)
    {
        var emergencyTable = emergencyEntity.ToEmergencyDataTable();
        var locationTable = emergencyEntity.Location.ToLocationDataTable(emergencyEntity.Street);
        var sourceTable = emergencyEntity.Source.ToSourceDataTable();

        return connection.QuerySingleAsync<int>(
            "[dbo].[CreateEmergency]",
            new
            {
                Emergency = emergencyTable.AsTableValuedParameter("dbo.EmergencyUDT"),
                Location = locationTable.AsTableValuedParameter("dbo.LocationUDT"),
                Source = sourceTable.AsTableValuedParameter("dbo.SourceUDT")
            },
            commandType: System.Data.CommandType.StoredProcedure
        );
    }

    public Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize)
    {

        return connection.QueryAsync<Emergency, Location, Source, Street, Emergency>(
        "[dbo].[GetEmergenciesByPage]",
        (emergency, location, source, street) =>
        {
            emergency.Location = location;
            emergency.Source = source;
            emergency.Street = street;
            return emergency;
        },
        new { Page = page, Pagesize = pagesize },
        commandType: System.Data.CommandType.StoredProcedure
        );
    }

    public Task<IEnumerable<Emergency>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate)
    {

        return connection.QueryAsync<Emergency, Location, Source, Street, Emergency>(
        "[dbo].[GetEmergenciesForPeriod]",
        (emergency, location, source, street) =>
        {
            emergency.Location = location;
            emergency.Source = source;
            emergency.Street = street;
            return emergency;
        },
        new { StartDate = startDate, EndDate = endDate },
        commandType: System.Data.CommandType.StoredProcedure
        );

    }

    public async Task<Emergency> GetEmergencyByIdAsync(int id)
    {
        using var multi = await connection.QueryMultipleAsync(
            "[dbo].[GetEmergencyById]",
            new { Id = id },
            commandType: System.Data.CommandType.StoredProcedure
        );
        var emergency = await multi.ReadSingleAsync<Emergency>();
        emergency.Location = await multi.ReadSingleAsync<Location>();
        emergency.Source = await multi.ReadSingleAsync<Source>();
        emergency.Street = await multi.ReadSingleAsync<Street>();

        return emergency ?? throw new KeyNotFoundException($"Emergency with ID {id} not found.");
    }
}
