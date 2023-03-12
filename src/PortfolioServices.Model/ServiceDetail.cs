namespace PortfolioServices.Model;

public class ServiceDetail
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? ImageUtilityId { get; set; }
    public Guid? ServiceId { get; set; }
}
