using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class ServiceDetailDto
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

    [DataMember]
    public Guid? ServiceId { get; set; }
}
