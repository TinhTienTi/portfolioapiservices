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
            var irq = lr.GetQueryable<ImageUtilities>();

            var result = (from cate in crq.Where(c => c.Object == LanguageObjectConstants.About)
                          from about in arq.Where(c => cate.Tid == c.TypeId).DefaultIfEmpty()
                          from img in irq.Where(x => x.GroupId == about.ImageGroupId).DefaultIfEmpty()
                          from language in lrq.Where(l => l.Key == about.Tid && l.Object == LanguageObjectConstants.About && l.Code == languageId).DefaultIfEmpty()
                          orderby cate.Priority ascending
                          select new ProfileResponseDto
                          {
                              Category = cate.Value,
                              Value = language.Value,
                              ImgUrl = cate.Value == "Image" ? img.Name : language.Value
                          });

            return await Task.FromResult(result);
        }

        public async Task<IQueryable<ClientProfileResponseDto>> GetClientInfoQueryableAsync(string languageId)
        {
            try
            {
                var cr = serviceProvider.GetService<IGenericRepository<Client, ClientDto>>();

                var crq = cr.GetQueryable<Client>();
                var ccrq = cr.GetQueryable<ClientComment>();
                var lrq = cr.GetQueryable<Language>();
                var irq = cr.GetQueryable<ImageUtilities>();

                var result = (from c in crq
                              from cc in ccrq.Where(cc => cc.ClientId == c.Tid)
                              from img in irq.Where(img=>img.GroupId == c.ImageGroupId).DefaultIfEmpty()
                              from l in lrq.Where(l => l.Key == cc.Tid && l.Object == LanguageObjectConstants.ClientComment && l.Code == languageId).DefaultIfEmpty()
                              select new ClientProfileResponseDto
                              {
                                  ImageUrl = img.Name ,
                                  Client = c.Name,
                                  Comment = l.Value
                              });
                return await Task.FromResult(result);
            }
            catch
            {
                throw;
            }
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
            var irq = lr.GetQueryable<ImageUtilities>();

            var result = (from s in srq
                          from sd in sdrq.Where(x => x.ServiceId == s.Tid)
                          from l in lrq.Where(x => x.Key == s.Tid && x.Object == LanguageObjectConstants.Service && x.Code == languageId)
                          from l2 in lrq.Where(x => x.Key == sd.Tid && x.Object == LanguageObjectConstants.ServiceDetail && x.Code == languageId)
                          from img in irq.Where(x => x.GroupId == sd.ImageGroupId).DefaultIfEmpty()
                          select new ServiceProfileResponseDto
                          {
                              Title = l.Value,
                              SubTitle = l2.Value,
                              ImgUrl = img.Name
                          });

            return await Task.FromResult(result);
        }
    }
}
