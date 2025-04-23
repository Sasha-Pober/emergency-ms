using Services.DTO;

namespace Services.Interfaces;

public interface IEmergencyService
{
    Task CreateEmergency(EmergencyDTO emergency);
    Task<IEnumerable<EmergencyDTO>> GetEmergencies(int page, int pagesize);
}
