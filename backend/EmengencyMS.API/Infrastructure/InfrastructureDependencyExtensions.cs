using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class InfrastructureDependencyExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Main");
        services.AddTransient<SqlConnection>(_ => new SqlConnection(connectionString));
        services.AddScoped<IEmergencyRepository, EmergencyRepository>();
        services.AddAuthorizationCore();
        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
        services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
        });
        services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<AppDbContext>().AddSignInManager();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}
