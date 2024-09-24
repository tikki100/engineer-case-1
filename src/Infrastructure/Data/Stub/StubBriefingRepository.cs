using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repositories.Stub;

public class StubBriefingRepository : IBriefingRepository
{
    private readonly ILogger _logger;
    private readonly IDataStore _dataStore;

    public StubBriefingRepository(ILogger<StubBriefingRepository> logger, IDataStore dataStore)
    {
        _logger = logger;
        _dataStore = dataStore;
    }

    public Task<Briefing?> GetBriefingByAssetIdAsync(string assetId)
    {
        _logger.LogInformation("Getting briefing by asset id {assetId}", assetId);

        var briefing = _dataStore.Briefings.FirstOrDefault(b => b.AssetId == assetId);

        return Task.FromResult(briefing);
    }
}
