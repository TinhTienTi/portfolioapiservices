using PortfolioServices.Dto;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface ICategoryBo
    {
        Task<CategoriesDto> CreateAsync(CategoriesDto home);

        Task<IEnumerable<CategoriesDto>> GetAsync();

        Task<CategoriesDto> GetAsync(Guid Tid);
    }
}
