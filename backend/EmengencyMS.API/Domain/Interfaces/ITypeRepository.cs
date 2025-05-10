using Domain.Entities;

namespace Domain.Interfaces;

public interface ITypeRepository
{
    Task<TypeEntity> GetAllTypesAsync();
}