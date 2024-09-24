using Core.Entities;

namespace Core.Interfaces;

public interface IContentDistributionService
{
    Task<ContentDistribution?> GetContentDistributionByIdAsync(string id);

    Task<ContentDistributionAsset?> GetContentDistributionAssetByAssetIdAsync(string assetId);
    
    Task<ContentDistribution> CreateContentDistributionAsync(ContentDistribution contentDistribution);
    Task<ContentDistribution> UpdateContentDistributionAsync(ContentDistribution contentDistribution);
    Task<bool> DeleteContentDistributionAsync(string id);
}