using PortfolioServices.Dto;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface ILanguageBo
    {
        Task<LanguageDto> CreateAsync(LanguageDto home);

        Task<IEnumerable<LanguageDto>> GetAsync();

        Task<LanguageDto> GetAsync(Guid Tid);
    }
}
