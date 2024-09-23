using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repositories.Stub;

public class StubAssetrepository : IAssetRepository
{
    private readonly ILogger _logger;

    public StubAssetrepository(ILogger<StubAssetrepository> logger)
    {
        _logger = logger;
    }

    public Task<Asset> GetAssetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids)
    {
        throw new NotImplementedException();
    }
}
