using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class CategoriesDto
{
    [DataMember]
    public Guid Tid { get; set; }

    [DataMember]
    public DateTimeOffset? CreatedAt { get; set; }

    [DataMember]
    public DateTimeOffset? ModifiedAt { get; set; }

    [DataMember]
    public string Object { get; set; }

    [DataMember]
    public string Value { get; set; }

    [DataMember]
    public Int16 Priority { get; set; }
}
