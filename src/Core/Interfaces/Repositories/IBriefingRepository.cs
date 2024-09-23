using Core.Entities;

namespace Core.Interfaces;

public interface IBriefingRepository
{
    Task<Briefing> GetBriefingByIdAsync(string id);
    Task<ICollection<Briefing>> GetBriefingsByIdsAsync(ICollection<string> ids);
}
