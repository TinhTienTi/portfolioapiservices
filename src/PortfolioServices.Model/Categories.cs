namespace PortfolioServices.Model;

public class Categories
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string Object { get; set; }
    public string Value { get; set; }
}
