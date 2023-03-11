using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo
{
    public class LanguageBo : ILanguageBo
    {
        private readonly IGenericRepository<Language, LanguageDto> lr;

        public LanguageBo(IGenericRepository<Language, LanguageDto> lr)
        {
            this.lr = lr;
        }

        public async Task<LanguageDto> CreateAsync(LanguageDto home)
        {
            return await lr.AddAsync(home);
        }

        public async Task<IEnumerable<LanguageDto>> GetAsync()
        {
            return await lr.GetAllAsync();
        }

        public async Task<LanguageDto> GetAsync(Guid Tid)
        {
            return await Task.FromResult(lr.GetById(Tid));
        }
    }
}
