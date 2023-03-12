using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo
{
    public class AboutBo : IAboutBo
    {
        private readonly IGenericRepository<About, AboutDto> ar;

        public AboutBo(IGenericRepository<About, AboutDto> ar)
        {
            this.ar = ar;
        }

        public async Task<AboutDto> CreateAsync(AboutDto home)
        {
            return await ar.AddAsync(home);
        }

        public async Task<IEnumerable<AboutDto>> GetAsync()
        {
            return await ar.GetAllAsync();
        }

        public async Task<AboutDto> GetAsync(Guid Tid)
        {
            return await Task.FromResult(ar.GetById(Tid));
        }
    }
}
