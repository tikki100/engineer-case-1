using Microsoft.Extensions.Logging;

using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repositories.Stub;

public class StubContentDistributionRepository : IContentDistributionRepository
{
    private readonly ILogger _logger;

    public StubContentDistributionRepository(ILogger<StubContentDistributionRepository> logger)
    {
        _logger = logger;
    }

    public Task<ContentDistribution> GetContentDistributionByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}
