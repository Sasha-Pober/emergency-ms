
using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmergencyRepository
{
    Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize);
}
