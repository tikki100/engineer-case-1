using Core.Criterias;
using Core.Entities;
using Core.Enums;

namespace Core.Interfaces;

public interface IBriefingService
{
    Task<IAsyncEnumerable<Briefing>> GetBriefingsAsync(BriefingCriteria criteria);

    Task<Briefing> GetBriefingByIdAsync(int id);

    Task<Briefing> CreateBriefingAsync(Briefing briefing);

    Task<Briefing> UpdateBriefingAsync(Briefing briefing);
    Task<bool> DeleteBriefingAsync(int id);
    
    Task<bool> UpdateBriefingStatusAsync(int briefingId, BriefingStatus status);
}
