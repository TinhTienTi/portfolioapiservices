using PortfolioServices.Dto.Others;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IQueryable<HomeProfileResponse>> GetHomeInfoQueryableAsync(string languageId);
    }
}
