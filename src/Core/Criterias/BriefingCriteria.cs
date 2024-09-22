using Core.Enums;

namespace Core.Criterias;

public class BriefingCriteria
{
    public BriefingStatus? Status { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
}
