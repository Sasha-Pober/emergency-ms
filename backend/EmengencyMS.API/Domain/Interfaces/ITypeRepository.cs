using Domain.Entities;
using Domain.Entities.Types;

namespace Domain.Interfaces;

public interface ITypeRepository
{
    Task<TypeEntity> GetAllTypesAsync();
    Task<IEnumerable<EmergencyType>> GetEmergencyTypes();
    Task<IEnumerable<EmergencySubType>> GetEmergencySubTypes();
}