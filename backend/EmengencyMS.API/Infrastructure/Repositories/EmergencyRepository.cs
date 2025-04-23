using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Infrastructure.Repositories;

internal class EmergencyRepository : IEmergencyRepository
{
    private readonly string _connectionString;

    public EmergencyRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Main");
    }

    public async Task CreateEmergency(Emergency emergencyEntity)
    {
        using var connection = new SqlConnection(_connectionString);
        
        var emergencyTable = emergencyEntity.ToEmergencyDataTable();
        var locationTable = emergencyEntity.Location.ToLocationDataTable();
        var sourceTable = emergencyEntity.Source.ToSourceDataTable();

        await connection.ExecuteAsync(
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
        using (var connection = new SqlConnection(_connectionString))
        {
            return connection.QueryAsync<Emergency, Location, Source, Emergency>(
            "[dbo].[GetEmergenciesByPage]",
            (emergency, location, source) =>
            {
                emergency.Location = location;
                emergency.Source = source;
                return emergency;
            },
            new { Page = page, Pagesize = pagesize },
            commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
