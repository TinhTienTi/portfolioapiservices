using PortfolioServices.Dto.Others;

namespace PortfolioServices.Api.Bo.Interfaces
{
    public interface IProfileBo
    {
        Task<IQueryable<ProfileResponseDto>> GetAboutInfoQueryableAsync(string languageId);

        Task<IQueryable<ClientProfileResponseDto>> GetClientInfoQueryableAsync(string languageId);

        Task<IQueryable<ProfileResponseDto>> GetHomeInfoQueryableAsync(string languageId);

        Task<IQueryable<PortfolioProfileResponseDto>> GetPortfolioInfoQueryableAsync(string languageId);

        Task<IQueryable<ServiceProfileResponseDto>> GetServiceInfoQueryableAsync(string languageId);
    }
}
