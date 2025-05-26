using Domain.Entities;
using Domain.Interfaces.Analytics;
using Domain.Interfaces.Repositories;
using Infrastructure.Algorithms;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDependencyExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Main");

        services.AddTransient<SqlConnection>(_ => new SqlConnection(connectionString));
        services.AddScoped<IVikorSolver, VikorSolver>();
        services.AddScoped<IEmergencyRepository, EmergencyRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IAnalyticsRepository, AnalyticsRepository>();


        services.AddAuthorization();
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
