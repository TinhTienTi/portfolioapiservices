using PortfolioServices.Dto.Others;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IQueryable<AboutProfileResponse>> GetAboutInfoQueryableAsync(string languageId);

        Task<IQueryable<HomeProfileResponse>> GetHomeInfoQueryableAsync(string languageId);
    }
}
