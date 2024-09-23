namespace Core.Entities;

public class ContentDistribution
{
    public string ContentId { get; set; } = string.Empty;
    public DateTime? DistributionDate { get; set; }
    public List<string> DistributionChannels { get; set; } = [];
    public List<string> DistributionMethods { get; set; } = [];
    public List<ContentDistributionAsset> Assets { get; set; } = [];
}
