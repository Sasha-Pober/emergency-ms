using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;

namespace Services;

public static class ServicesDependecyExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmergencyService, EmergencyService>();
        services.AddScoped<IImageService, ImageService>();
    }
}
