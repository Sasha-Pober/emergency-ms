using Domain.Interfaces.Repositories;
using Services.DTO;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Implementations;

internal class TypeService(ITypeRepository typeRepository) : ITypeService
{
    public async Task<TypeDTO> GetAllTypesAsync()
    {
        var result = await typeRepository.GetAllTypesAsync();
        return result.MapToDTO();
    }

    public async Task<IEnumerable<EmergencySubTypeDTO>> GetEmergencySubTypes()
    {
        var result = await typeRepository.GetEmergencySubTypes();
        return result.Select(x => x.MapToDTO());
    }

    public async Task<IEnumerable<EmergencyTypeDTO>> GetEmergencyTypes()
    {
        var result = await typeRepository.GetEmergencyTypes();
        return result.Select(x => x.MapToDTO());
    }
}
