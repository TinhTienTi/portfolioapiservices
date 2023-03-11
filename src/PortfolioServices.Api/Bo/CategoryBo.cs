using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo
{
    public class CategoryBo : ICategoryBo
    {
        private readonly IGenericRepository<Categories, CategoriesDto> cr;

        public CategoryBo(IGenericRepository<Categories, CategoriesDto> cr)
        {
            this.cr = cr;
        }

        public async Task<CategoriesDto> CreateAsync(CategoriesDto home)
        {
            return await cr.AddAsync(home);
        }

        public async Task<IEnumerable<CategoriesDto>> GetAsync()
        {
            return await cr.GetAllAsync();
        }

        public async Task<CategoriesDto> GetAsync(Guid Tid)
        {
            return await Task.FromResult(cr.GetById(Tid));
        }
    }
}
