using Core.Entities;

namespace Core.Interfaces;

public interface IBriefingRepository
{
    Task<Briefing?> GetBriefingByAssetIdAsync(string assetId);
}
