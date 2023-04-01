namespace PortfolioServices.Model;

public class Client
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string Name { get; set; }
    public Guid? ImageGroupId { get; set; }
}
