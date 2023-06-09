﻿namespace PortfolioServices.Model;

public class About
{
    public Guid Tid { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? ImageGroupId { get; set; }
}
