namespace PortfolioServices.Dto;

public class ImageUtilitiesDto
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string Name { get; set; }
    public string ObjectName { get; set; }
}
