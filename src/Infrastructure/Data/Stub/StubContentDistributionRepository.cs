using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repositories.Stub;

public class StubContentDistributionRepository : IContentDistributionRepository
{
    private readonly ILogger _logger;

    private readonly IDataStore _dataStore;

    public StubContentDistributionRepository(ILogger<StubContentDistributionRepository> logger, IDataStore dataStore)
    {
        _logger = logger;
        _dataStore = dataStore;
    }

    public Task<ContentDistributionAsset?> GetContentDistributionAssetByAssetIdAsync(string assetId)
    {
        var contentDistributionAsset = _dataStore.ContentDistributions
            .SelectMany(contentDistribution => contentDistribution.Assets)
            .FirstOrDefault(contentDistributionAsset => contentDistributionAsset.AssetId == assetId);

        return Task.FromResult(contentDistributionAsset);
    }

    public Task<ContentDistribution?> GetContentDistributionByIdAsync(string id)
    {
        var contentDistribution = _dataStore.ContentDistributions
            .FirstOrDefault(contentDistribution => contentDistribution.ContentId == id);

        return Task.FromResult(contentDistribution);
    }
}