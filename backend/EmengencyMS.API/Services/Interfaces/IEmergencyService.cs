using Services.DTO;

namespace Services.Interfaces;

public interface IEmergencyService
{
    Task<int> CreateEmergency(EmergencyDTO emergency);
    Task<IEnumerable<EmergencyDTO>> GetAllEmergencies(int page, int pagesize);
    Task<IEnumerable<EmergencyDTO>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate);
    Task<EmergencyDTO?> GetEmergencyById(int id);
}
