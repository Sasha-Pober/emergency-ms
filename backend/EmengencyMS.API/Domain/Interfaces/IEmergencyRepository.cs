
using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmergencyRepository
{
    Task CreateEmergency(Emergency emergencyEntity);
    Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize);
}
