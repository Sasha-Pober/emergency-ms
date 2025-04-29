using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Presentation;

public static class PresentationDependencyExtensions
{
    public static void ConfigurePresentation(this IServiceCollection services)
    {
        services.ConfigureServices();
    }
}
