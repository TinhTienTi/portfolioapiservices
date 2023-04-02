using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class PortfolioDto
{
    [DataMember]
    public Guid Tid { get; set; }

    [DataMember]
    public DateTimeOffset? CreatedAt { get; set; }

    [DataMember]
    public DateTimeOffset? ModifiedAt { get; set; }

    [DataMember]
    public Guid? ImageGroupId { get; set; }

    [DataMember]
    public Guid? Title { get; set; }

    [DataMember]
    public Guid? SubTitle { get; set; }
}
