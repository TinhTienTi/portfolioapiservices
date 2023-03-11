namespace PortfolioServices.Dto;

public class HomeDto
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? TypeId { get; set; }
}
