using Domain.Interfaces;
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
}
