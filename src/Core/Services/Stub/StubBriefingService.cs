using Microsoft.Extensions.Logging;

using Core.Criterias;
using Core.Entities;
using Core.Interfaces;
using Core.Enums;

namespace Core.Services.Stub;

public class StubBriefingService : IBriefingService
{
    private readonly ILogger<StubBriefingService> _logger;
    private readonly IBriefingRepository _briefingRepository;
    public StubBriefingService(ILogger<StubBriefingService> logger, 
        IBriefingRepository briefingRepository,
        IContentDistributionService contentDistributionService) 
    {
        _logger = logger;
        _briefingRepository = briefingRepository;
    }

    public Task<Briefing> CreateBriefingAsync(Briefing briefing)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBriefingAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Briefing?> GetBriefingByIdAsync(string assetId)
    {
        return await _briefingRepository.GetBriefingByAssetIdAsync(assetId);
    }

    public Task<ICollection<Briefing>> GetBriefingsByCriteriaAsync(BriefingCriteria criteria)
    {
        throw new NotImplementedException();
    }

    public Task<Briefing> UpdateBriefingAsync(Briefing briefing)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBriefingStatusAsync(string briefingId, BriefingStatus status)
    {
        throw new NotImplementedException();
    }
}
