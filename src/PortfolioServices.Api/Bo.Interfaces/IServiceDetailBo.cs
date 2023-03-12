using PortfolioServices.Dto;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface IServiceDetailBo
    {
        Task<ServiceDetailDto> CreateAsync(ServiceDetailDto home);

        Task<IEnumerable<ServiceDetailDto>> GetAsync();

        Task<ServiceDetailDto> GetAsync(Guid Tid);
    }
}
