using Domain.Entities.Types;

namespace Domain.Interfaces.Repositories;

public interface ITypeRepository
{
    Task<TypeEntity> GetAllTypesAsync();
    Task<IEnumerable<EmergencyType>> GetEmergencyTypes();
    Task<IEnumerable<EmergencySubType>> GetEmergencySubTypes();
}