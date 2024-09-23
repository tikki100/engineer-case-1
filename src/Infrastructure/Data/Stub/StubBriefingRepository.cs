using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repositories.Stub;

public class StubBriefingRepository : IBriefingRepository
{
    private readonly ILogger _logger;

    public StubBriefingRepository(ILogger<StubBriefingRepository> logger)
    {
        _logger = logger;
    }

    public Task<Briefing> GetBriefingByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Briefing>> GetBriefingsByIdsAsync(ICollection<string> ids)
    {
        throw new NotImplementedException();
    }
}
