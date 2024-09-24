using Core.Interfaces;
using Core.Services.Stub;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAssetService, StubAssetService>();
        services.AddScoped<IBriefingService, StubBriefingService>();
        services.AddScoped<IContentDistributionService, StubContentDistributionService>();

        return services;
    }
}