namespace PortfolioServices.Model
{
    public class Portfolio
    {
        public Guid Tid { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public Guid? ImageGroupId { get; set; }
        public Guid? Title { get; set; }
        public Guid? SubTitle { get; set; }
    }
}
