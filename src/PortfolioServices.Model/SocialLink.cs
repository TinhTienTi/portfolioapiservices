namespace PortfolioServices.Model;

public class SocialLink
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public bool? Disable { get; set; }
    public Guid? ImageGroupId { get; set; }
}
