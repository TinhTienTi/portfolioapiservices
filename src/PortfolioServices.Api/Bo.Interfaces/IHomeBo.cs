using PortfolioServices.Dto;
using PortfolioServices.Model;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface IHomeBo
    {
        Task<HomeDto> CreateAsync(HomeDto home);

        Task<IEnumerable<HomeDto>> GetAsync();

        Task<HomeDto> GetAsync(Guid Tid);
    }
}
