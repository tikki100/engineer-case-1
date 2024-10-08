using Core.Criterias;
using Core.Entities;

namespace Core.Interfaces;

public interface IAssetRepository
{
    Task<Asset?> GetAssetByIdAsync(string id);
    Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids);

    Task<ICollection<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take);
}
