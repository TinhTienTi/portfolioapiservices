using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo
{
    public class HomeBo : IHomeBo
    {
        private readonly IGenericRepository<Home, HomeDto> hr;

        public HomeBo(IGenericRepository<Home, HomeDto> hr)
        {
            this.hr = hr;
        }

        public async Task<HomeDto> CreateAsync(HomeDto home)
        {
            return await hr.AddAsync(home);
        }

        public async Task<IEnumerable<HomeDto>> GetAsync()
        {
            return await hr.GetAllAsync();
        }

        public async Task<HomeDto> GetAsync(Guid Tid)
        {
            return await Task.FromResult(hr.GetById(Tid));
        }
    }
}
