using Core.Enums;

namespace Core.Entitites;

public class Asset
{
    public string AssetId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string FileFormat { get; set; } = string.Empty;
    public string FileSize { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public string VersionNumber { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;
    public AssetStatus Status { get; set; }
}
