namespace PortfolioServices.Model;

public class Service
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? ImageUtilityId { get; set; }
}
