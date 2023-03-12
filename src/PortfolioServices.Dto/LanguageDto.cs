using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class LanguageDto
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
    public Guid? Key { get; set; }

    [DataMember]
    public string Code { get; set; }

    [DataMember]
    public string Value { get; set; }
}
