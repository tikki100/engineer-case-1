using Core.Criterias;
using Core.Entities;

namespace Core.Interfaces;

public interface IAssetService
{
    Task<Asset> GetAssetByIdAsync(string id);
    Task<IAsyncEnumerable<Asset>> GetAssetsByIdsAsync(ICollection<string> ids);
    
    Task<IAsyncEnumerable<Asset>> GetAllAssetsAsync(int skip, int take);
    Task<IAsyncEnumerable<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take);

    Task<Asset> GetAssetByBriefingIdAsync(string briefingId);

    Task<Asset> CreateAssetAsync(Asset asset);
    Task<Asset> UpdateAssetAsync(Asset asset);

    Task<bool> DeleteAssetAsync(string id);

    Task<Stream> DownloadAssetAsync(string id);

     
}