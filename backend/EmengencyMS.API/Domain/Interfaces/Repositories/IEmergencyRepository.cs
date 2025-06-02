using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IEmergencyRepository
{
    Task<int> CreateEmergency(Emergency emergencyEntity);
    Task<IEnumerable<Emergency>> GetEmergencies(int page, int pagesize);
    Task<IEnumerable<Emergency>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate);
    Task<Emergency> GetEmergencyByIdAsync(int id);
    Task<IEnumerable<Emergency>> GetUnapprovedEmergencies();
}
