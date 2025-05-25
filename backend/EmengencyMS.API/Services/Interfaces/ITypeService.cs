using Services.DTO;

namespace Services.Interfaces;

public interface ITypeService
{
    Task<TypeDTO> GetAllTypesAsync();
    Task<IEnumerable<EmergencyTypeDTO>> GetEmergencyTypes();
    Task<IEnumerable<EmergencySubTypeDTO>> GetEmergencySubTypes();
}