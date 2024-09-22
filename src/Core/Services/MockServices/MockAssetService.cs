using Core.Criterias;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services.MockServices;

public class MockAssetService : IAssetService
{
    public Task<Asset> CreateAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAssetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncEnumerable<Asset>> GetAllAssetsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncEnumerable<Asset>> GetAssetByBriefingIdAsync(string briefingId)
    {
        throw new NotImplementedException();
    }

    public Task<Asset?> GetAssetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncEnumerable<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<IAsyncEnumerable<Asset>> GetAssetsByIdsAsync(ICollection<string> ids)
    {
        throw new NotImplementedException();
    }

    public Task<Asset> UpdateAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }
}
