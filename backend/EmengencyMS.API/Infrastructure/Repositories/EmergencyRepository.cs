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

    public async Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryAsync<Emergency, Location, Source, Emergency>(
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
