
using Domain.Entities;
using Domain.Entities.Types;

namespace Domain.Interfaces;

public interface IEmergencyRepository
{
    Task<int> CreateEmergency(Emergency emergencyEntity);
    Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize);
    Task<IEnumerable<Emergency>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate);
    Task<IEnumerable<EmergencyType>> GetEmergencyTypes();
    Task<IEnumerable<EmergencySubType>> GetEmergencySubTypes();
}
