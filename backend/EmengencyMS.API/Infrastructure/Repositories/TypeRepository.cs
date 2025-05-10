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
            result.RegionTypes = multi.Read<RegionType>();
            result.SourceTypes = multi.Read<SourceType>();
            return result;
        }
    }
}
