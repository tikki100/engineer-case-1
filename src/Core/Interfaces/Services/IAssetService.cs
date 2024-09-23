using Core.Criterias;
using Core.Entities;

namespace Core.Interfaces;

public interface IAssetService
{
    Task<Asset?> GetAssetByIdAsync(string id);
    Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids);
    
    Task<ICollection<Asset>> GetAllAssetsAsync(int skip, int take);
    Task<ICollection<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take);

    Task<ICollection<Asset>> GetAssetsByContentDistributionId(string contentId);

    Task<Asset> GetAssetByBriefingIdAsync(string briefingId);

    Task<Asset> CreateAssetAsync(Asset asset);
    Task<Asset> UpdateAssetAsync(Asset asset);

    Task<bool> DeleteAssetAsync(string id);

    Task<Stream> DownloadAssetAsync(string id);

     
}