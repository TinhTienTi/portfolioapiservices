namespace PortfolioServices.Dto.Others;

public class HomeProfileResponse
{
    public Guid HomeId { get; set; }
    public string Value { get; set; }
    public Guid CategoryId { get; set; }
    public string Category { get; set; }
}
