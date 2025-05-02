using Domain.Entities;
using Domain.Interfaces;
using Services.DTO;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Implementations;

internal class EmergencyService(IEmergencyRepository repository) 
    : IEmergencyService
{
    public async Task<int> CreateEmergency(EmergencyDTO emergency)
    {
        var emergencyEntity = emergency.MapToEntity();
        return await repository.CreateEmergency(emergencyEntity);
    }

    public async Task<IEnumerable<EmergencyDTO>> GetAllEmergencies(int page, int pagesize)
    {
        var emergencies = await repository.GetEmergencies(page, pagesize);
        return emergencies.Select(x => x.MapToDTO());
    }

    public async Task<IEnumerable<EmergencyDTO>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate)
    {
        var emergencies = await repository.GetEmergenciesForPeriod(startDate, endDate);
        return emergencies.Select(x => x.MapToDTO());
    }

    public async Task<IEnumerable<EmergencyTypeDTO>> GetEmergencyTypes()
    {
        var result = await repository.GetEmergencyTypes();
        return result.Select(x => x.MapToDTO());
    }
}
