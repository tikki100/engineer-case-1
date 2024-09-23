using Core.Entities;

namespace Core.Interfaces;

public interface IDataStore
{
    ICollection<Asset> Assets { get; }
    ICollection<Briefing> Briefings { get; }
    ICollection<ContentDistribution> ContentDistributions { get; }
}

