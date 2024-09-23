using Core.Criterias;
using Core.Entities;
using Core.Enums;

namespace Core.Interfaces;

public interface IBriefingService
{

    Task<Briefing?> GetBriefingByIdAsync(string id);
    Task<ICollection<Briefing>> GetBriefingsByCriteriaAsync(BriefingCriteria criteria);


    Task<Briefing> CreateBriefingAsync(Briefing briefing);

    Task<Briefing> UpdateBriefingAsync(Briefing briefing);
    Task<bool> DeleteBriefingAsync(string id);
    
    Task<bool> UpdateBriefingStatusAsync(string briefingId, BriefingStatus status);
}
