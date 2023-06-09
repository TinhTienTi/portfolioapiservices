﻿using System.Runtime.Serialization;

namespace PortfolioServices.Dto;

public class ServiceDto
{

    [DataMember]
    public Guid Tid { get; set; }

    [DataMember]
    public DateTimeOffset? CreatedAt { get; set; }

    [DataMember]
    public DateTimeOffset? ModifiedAt { get; set; }
}
