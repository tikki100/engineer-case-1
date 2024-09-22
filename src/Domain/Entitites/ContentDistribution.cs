using System;

namespace Domain.Entitites;

public class ContentDistribution
{
    public DateTime? DistributionDate { get; set; }
    public List<string> DistributionChannels { get; set; } = [];
    public List<string> DistributionMethods { get; set; } = [];
    public List<Asset> Assets { get; set; } = [];
}
