using Domain.Interfaces.Repositories;
using Services.DTO;
using Services.Interfaces;
using Services.Mappings;

namespace Services.Implementations;

internal class EmergencyService(IEmergencyRepository emergencyRepository, IImageRepository imageRepository)
    : IEmergencyService
{
    public async Task<int> CreateEmergency(EmergencyDTO emergency)
    {
        var emergencyEntity = emergency.MapToEntity();
        return await emergencyRepository.CreateEmergency(emergencyEntity);
    }

    public async Task<IEnumerable<EmergencyDTO>> GetAllEmergencies(int page, int pagesize)
    {
        var emergencies = await emergencyRepository.GetEmergencies(page, pagesize);
        return emergencies.Select(x => x.MapToDTO());
    }

    public async Task<IEnumerable<EmergencyDTO>> GetUnapprovedEmergencies()
    {
        var emergencies = await emergencyRepository.GetUnapprovedEmergencies();
        return emergencies.Select(x => x.MapToDTO());
    }

    public async Task<IEnumerable<EmergencyDTO>> GetEmergenciesForPeriod(DateTime startDate, DateTime endDate)
    {
        var emergencies = await emergencyRepository.GetEmergenciesForPeriod(startDate, endDate);
        return emergencies.Select(x => x.MapToDTO());
    }

    public async Task<EmergencyDTO?> GetEmergencyById(int id)
    {
        var result = await emergencyRepository.GetEmergencyByIdAsync(id);
        var mappedEmergency = result.MapToDTO();
        if (result != null)
        {
            var images = await imageRepository.GetImagesByEmergencyId(id);
            mappedEmergency.Images = images.Select(img => img.MapToDTO()).ToList();
        }
        return mappedEmergency;
    }
}
