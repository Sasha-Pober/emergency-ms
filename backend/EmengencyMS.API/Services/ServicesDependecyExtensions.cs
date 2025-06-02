using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Implementations.JWT;
using Services.Interfaces;
using Services.Interfaces.JWT;

namespace Services;

public static class ServicesDependecyExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmergencyService, EmergencyService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ITypeService, TypeService>();
        services.AddScoped<IAnalyticsService, AnalyticsService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}
