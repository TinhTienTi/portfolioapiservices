using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class AboutDto
{
    [DataMember]
    public Guid Tid { get; set; }

    [DataMember]
    public DateTimeOffset? CreatedAt { get; set; }

    [DataMember]
    public DateTimeOffset? ModifiedAt { get; set; }

    [DataMember]
    public Guid? TypeId { get; set; }

    [DataMember]
    public Guid? ImageGroupId { get; set; }
}
