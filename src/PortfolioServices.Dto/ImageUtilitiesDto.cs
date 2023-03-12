using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class ImageUtilitiesDto
{

    [DataMember]
    public Guid Tid { get; set; }

    [DataMember]
    public DateTimeOffset? CreatedAt { get; set; }

    [DataMember]
    public DateTimeOffset? ModifiedAt { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string ObjectName { get; set; }
}
