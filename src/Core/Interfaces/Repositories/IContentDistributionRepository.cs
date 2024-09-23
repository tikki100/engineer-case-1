using Core.Entities;

namespace Core.Interfaces;

public interface IContentDistributionRepository
{
    Task<ContentDistribution?> GetContentDistributionByIdAsync(string id);

}
