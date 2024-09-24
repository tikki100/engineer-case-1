using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Core.Services.Stub;

public class StubContentDistributionService : IContentDistributionService
{
    private readonly ILogger<StubContentDistributionService> _logger;
    private readonly IContentDistributionRepository _contentDistributionRepository;
    public StubContentDistributionService(ILogger<StubContentDistributionService> logger, 
        IContentDistributionRepository contentDistributionRepository) 
    {
        _logger = logger;
        _contentDistributionRepository = contentDistributionRepository;
    }

    public Task<ContentDistribution> CreateContentDistributionAsync(ContentDistribution contentDistribution)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteContentDistributionAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ContentDistributionAsset?> GetContentDistributionAssetByAssetIdAsync(string assetId)
    {
        return await _contentDistributionRepository.GetContentDistributionAssetByAssetIdAsync(assetId);
    }

    public async Task<ContentDistribution?> GetContentDistributionByIdAsync(string id)
    {
        return await _contentDistributionRepository.GetContentDistributionByIdAsync(id);
    }

    public Task<ContentDistribution> UpdateContentDistributionAsync(ContentDistribution contentDistribution)
    {
        throw new NotImplementedException();
    }
}
