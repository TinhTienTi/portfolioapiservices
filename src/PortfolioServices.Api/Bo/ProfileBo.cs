using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Dto.Others;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo
{
    public class ProfileBo : IProfileBo
    {
        private readonly IServiceProvider serviceProvider;

        public ProfileBo(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<IQueryable<HomeProfileResponse>> GetHomeInfoQueryableAsync(string languageId)
        {
            var lr = serviceProvider.GetService<IGenericRepository<Language, LanguageDto>>();
            var hr = serviceProvider.GetService<IGenericRepository<Home, HomeDto>>();
            var cr = serviceProvider.GetService<IGenericRepository<Categories, CategoriesDto>>();

            var hrq = lr.GetQueryable<Home>();
            var lrq = lr.GetQueryable<Language>();
            var crq = lr.GetQueryable<Categories>();

            var result = (from h in hrq
                          from c in crq.Where(c => c.Tid == h.TypeId).DefaultIfEmpty()
                          from l in lrq.Where(l => l.Key == h.Tid && l.Object == "Home" && l.Code == languageId).DefaultIfEmpty()
                          select new HomeProfileResponse
                          {
                              HomeId = h.Tid,
                              Value = l.Value,
                              CategoryId = c.Tid,
                              Category = c.Value
                          });

            return await Task.FromResult(result);
        }
    }
}
