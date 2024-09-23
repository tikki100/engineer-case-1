using Core.Criterias;
using Core.Entities;
using Core.Interfaces;
using System.Linq;

namespace Core.Services.Mock;

public class MockAssetService : IAssetService
{
    public Task<Asset> CreateAssetAsync(Asset asset)
    {
        return Task.FromResult(new Asset());
    }

    public Task<bool> DeleteAssetAsync(string id)
    {
        return Task.FromResult(true);
    }

    public Task<Stream> DownloadAssetAsync(string id)
    {
        return Task.FromResult(new MemoryStream() as Stream);
    }

    public Task<ICollection<Asset>> GetAllAssetsAsync(int skip, int take)
    {
        return Task.FromResult<ICollection<Asset>>(Array.Empty<Asset>());
    }

    public Task<Asset> GetAssetByBriefingIdAsync(string briefingId)
    {
        return Task.FromResult(new Asset());
    }

    public Task<Asset> GetAssetByIdAsync(string id)
    {
        return Task.FromResult<Asset>(new Asset());
    }

    public Task<ICollection<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take)
    {
        return Task.FromResult<ICollection<Asset>>(Array.Empty<Asset>());
    }

    public Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids)
    {
        return Task.FromResult<ICollection<Asset>>(Array.Empty<Asset>());
    }

    public Task<Asset> UpdateAssetAsync(Asset asset)
    {
        return Task.FromResult(new Asset());
    }
}
