using Services.DTO;

namespace Services.Interfaces;

public interface ITypeService
{
    Task<TypeDTO> GetAllTypesAsync();
}