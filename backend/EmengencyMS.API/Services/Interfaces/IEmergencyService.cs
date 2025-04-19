using Services.DTO;

namespace Services.Interfaces;

public interface IEmergencyService
{
    Task<IEnumerable<EmergencyDTO>> GetEmergencies(int page, int pagesize);
}
