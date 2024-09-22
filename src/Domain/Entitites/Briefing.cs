using Domain.Enums;

namespace Domain.Entitites;

public class Briefing
{
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public BriefingStatus Status { get; set; }
    public string Comments { get; set; } = string.Empty;
}
