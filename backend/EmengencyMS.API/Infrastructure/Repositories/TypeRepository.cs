using Dapper;
using Domain.Entities;
using Domain.Entities.Types;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

internal class TypeRepository(SqlConnection connection) : ITypeRepository
{
    public async Task<TypeEntity> GetAllTypesAsync()
    {
        var result = new TypeEntity();
        using (var multi = await connection.QueryMultipleAsync(
        "[dbo].[GetAllTypes]",
        commandType: System.Data.CommandType.StoredProcedure
        ))
        {
            result.Types = multi.Read<EmergencyType>();
            result.SubTypes = multi.Read<EmergencySubType>();
            result.Regions = multi.Read<Region>();
            result.SourceTypes = multi.Read<SourceType>();
            return result;
        }
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
