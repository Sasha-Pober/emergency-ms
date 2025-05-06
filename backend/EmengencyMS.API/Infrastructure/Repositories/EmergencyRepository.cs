using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

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

    public Task<IEnumerable<EmergencySubType>> GetEmergencySubTypes()
    {
        return connection.QueryAsync<EmergencySubType>("[dbo].[GetEmergencySubTypes]",
            commandType: System.Data.CommandType.StoredProcedure);
    }

    public Task<IEnumerable<EmergencyType>> GetEmergencyTypes()
    {
        return connection.QueryAsync<EmergencyType>("[dbo].[GetEmergencyTypes]",
            commandType: System.Data.CommandType.StoredProcedure);
    }
}
