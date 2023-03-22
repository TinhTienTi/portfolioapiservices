using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Dto.Others;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;
using PortfolioServices.Utilities;

namespace PortfolioServices.Api.Bo
{
    public class ProfileBo : IProfileBo
    {
        private readonly IServiceProvider serviceProvider;

        public ProfileBo(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<IQueryable<ProfileResponseDto>> GetAboutInfoQueryableAsync(string languageId)
        {
            var lr = serviceProvider.GetService<IGenericRepository<Language, LanguageDto>>();

            var arq = lr.GetQueryable<About>();
            var lrq = lr.GetQueryable<Language>();
            var crq = lr.GetQueryable<Categories>();

            var result = (from about in arq
                          from cate in crq.Where(c => c.Tid == about.TypeId && c.Object == LanguageObjectConstants.About)
                          from language in lrq.Where(l => l.Key == about.Tid && l.Object == LanguageObjectConstants.About && l.Code == languageId)
                          orderby cate.Priority ascending
                          select new ProfileResponseDto
                          {
                              Category = cate.Value,
                              Value = language.Value
                          });

            return await Task.FromResult(result);

        }

        public async Task<IQueryable<ProfileResponseDto>> GetHomeInfoQueryableAsync(string languageId)
        {
            var lr = serviceProvider.GetService<IGenericRepository<Language, LanguageDto>>();

            var hrq = lr.GetQueryable<Home>();
            var lrq = lr.GetQueryable<Language>();
            var crq = lr.GetQueryable<Categories>();

            var result = (from h in hrq
                          from c in crq.Where(c => c.Tid == h.TypeId && c.Object == LanguageObjectConstants.Home).DefaultIfEmpty()
                          from l in lrq.Where(l => l.Key == h.Tid && l.Object == LanguageObjectConstants.Home && l.Code == languageId).DefaultIfEmpty()
                          orderby c.Priority ascending
                          select new ProfileResponseDto
                          {
                              Category = c.Value,
                              Value = l.Value
                          });

            return await Task.FromResult(result);
        }

        public async Task<IQueryable<ServiceProfileResponseDto>> GetServiceInfoQueryableAsync(string languageId)
        {
            var lr = serviceProvider.GetService<IGenericRepository<Language, LanguageDto>>();

            var srq = lr.GetQueryable<Service>();
            var sdrq = lr.GetQueryable<ServiceDetail>();
            var lrq = lr.GetQueryable<Language>();
            var crq = lr.GetQueryable<Categories>();

            var result = (from sd in sdrq
                          from c in crq.Where(c => c.Tid == sd.TypeId && c.Object == LanguageObjectConstants.ServiceDetail)
                          from l in lrq.Where(l => l.Key == sd.Tid && l.Object == LanguageObjectConstants.ServiceDetail && l.Code == languageId)
                          select new
                          {
                              sd.Tid,
                              sd.ServiceId,
                              Category = c.Value,
                              Language = l.Value
                          }).ToList();

            var query = result
                    .GroupBy(c => c.ServiceId)
                    .Select(g => new {
                        CustId = g.Key,
                        Title = g.Where(c => c.ServiceId == g.Key)
                    });

            return null;
        }
    }
}
