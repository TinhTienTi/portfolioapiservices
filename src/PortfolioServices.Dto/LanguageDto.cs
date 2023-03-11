namespace PortfolioServices.Dto;

public class LanguageDto
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string Object { get; set; }
    public Guid? Key { get; set; }
    public string Code { get; set; }
    public string Value { get; set; }
}
