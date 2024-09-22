using Core.Enums;

namespace Core.Criterias;

public class AssetCriteria
{
    public AssetStatus? Status { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public FileFormat FileFormat { get; set; }
}