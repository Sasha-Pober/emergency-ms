using Domain.Interfaces;
using Services.DTO;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Implementations;

internal class EmergencyService(IEmergencyRepository repository) 
    : IEmergencyService
{
    public async Task CreateEmergency(EmergencyDTO emergency)
    {
        var emergencyEntity = emergency.MapToEntity();
        await repository.CreateEmergency(emergencyEntity);
    }

    public async Task<IEnumerable<EmergencyDTO>> GetEmergencies(int page, int pagesize)
    {
        var emergencies = await repository.GetEmergencies(page, pagesize);
        return emergencies.Select(x => x.MapToDTO());
    }
}
