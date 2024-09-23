using Core.Interfaces;
using Infrastructure.Data.Stub;
using Infrastructure.Repositories.Stub;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAssetDownloadRepository, StubAssetDownloadRepository>();
        services.AddSingleton<InMemoryDataStore>();

        return services;
    }
}