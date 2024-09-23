using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;
using Core.Criterias;

namespace Infrastructure.Repositories.Stub;

public class StubAssetRepository : IAssetRepository
{
    private readonly ILogger _logger;
    private readonly IDataStore _dataStore;

    public StubAssetRepository(ILogger<StubAssetRepository> logger, IDataStore dataStore)
    {
        _logger = logger;
        _dataStore = dataStore;
    }

    public Task<Asset?> GetAssetByIdAsync(string id)
    {
        var asset = _dataStore.Assets.FirstOrDefault(asset => asset.AssetId == id);
        return Task.FromResult(asset);
    }

    public Task<ICollection<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take)
    {
        var assets = _dataStore.Assets
            .Where(asset => !criteria.Status.HasValue || criteria.Status.Value == asset.Status)
            .Where(asset => !criteria.CreatedAfter.HasValue || criteria.CreatedAfter.Value <= asset.Timestamp)
            .Where(asset => !criteria.CreatedBefore.HasValue || criteria.CreatedBefore.Value >= asset.Timestamp)
            .Where(asset => !criteria.FileFormat.HasValue || criteria.FileFormat.Value == asset.FileFormat)
            .Skip(skip)
            .Take(take)
            .ToList();

        return Task.FromResult<ICollection<Asset>>(assets);
    }

    public Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids)
    {
        var assets = _dataStore.Assets
            .Where(asset => ids.Contains(asset.AssetId))
            .ToList();
        
        return Task.FromResult<ICollection<Asset>>(assets);
    }
}