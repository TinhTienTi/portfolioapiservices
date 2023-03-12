using PortfolioServices.Dto;

namespace PortfolioServices.Api.Bo.Interfaces;

public interface IAboutBo
{
    Task<AboutDto> CreateAsync(AboutDto home);

    Task<IEnumerable<AboutDto>> GetAsync();

    Task<AboutDto> GetAsync(Guid Tid);
}
