using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Analytics;
using Domain.Interfaces.Repositories;
using Infrastructure.Algorithms;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class InfrastructureDependencyExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection");

        services.AddTransient<SqlConnection>(_ => new SqlConnection(connectionString));
        services.AddScoped<IVikorSolver, VikorSolver>();
        services.AddScoped<IEmergencyRepository, EmergencyRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IAnalyticsRepository, AnalyticsRepository>();
        services.AddSingleton<IRsaKeyProvider, RsaKeyProvider>();


        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                var rsa = services.BuildServiceProvider().GetRequiredService<IRsaKeyProvider>().GetPrivateKey();
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };
                options.MapInboundClaims = false;
            });

        services.AddAuthorization();
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}
