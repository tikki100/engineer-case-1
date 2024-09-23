using Microsoft.Extensions.Logging;

using Core.Criterias;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services.Stub;

public class StubAssetService : IAssetService
{
    private readonly ILogger<StubAssetService> _logger;
    private readonly IAssetDownloadRepository _assetDownloadRepository;
    public StubAssetService(ILogger<StubAssetService> logger, IAssetDownloadRepository assetDownloadRepository) {
        _logger = logger;
        _assetDownloadRepository = assetDownloadRepository;

    }

    public Task<Asset> CreateAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAssetAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Stream> DownloadAssetAsync(string id)
    {
        return await _assetDownloadRepository.DownloadAsync(id);
    }

    public Task<ICollection<Asset>> GetAllAssetsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<Asset> GetAssetByBriefingIdAsync(string briefingId)
    {
        throw new NotImplementedException();
    }

    public Task<Asset> GetAssetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Asset>> GetAssetsByCriteriaAsync(AssetCriteria criteria, int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Asset>> GetAssetsByIdsAsync(ICollection<string> ids)
    {
        throw new NotImplementedException();
    }

    public Task<Asset> UpdateAssetAsync(Asset asset)
    {
        throw new NotImplementedException();
    }
}
