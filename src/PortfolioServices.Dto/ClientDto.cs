using System.Runtime.Serialization;

namespace PortfolioServices.Dto
{
    public class ClientDto
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
        public Guid? ImageGroupId { get; set; }
    }
}
