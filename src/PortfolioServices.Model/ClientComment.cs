namespace PortfolioServices.Model;

public partial class ClientComment
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? ClientId { get; set; }
}
