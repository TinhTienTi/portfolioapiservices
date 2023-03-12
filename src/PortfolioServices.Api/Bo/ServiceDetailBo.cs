using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;
using PortfolioServices.Model;
using PortfolioServices.Repositories.Interfaces;

namespace PortfolioServices.Api.Bo;

public class ServiceDetailBo : IServiceDetailBo
{
    private readonly IGenericRepository<ServiceDetail, ServiceDetailDto> sr;

    public ServiceDetailBo(IGenericRepository<ServiceDetail, ServiceDetailDto> sr)
    {
        this.sr = sr;
    }

    public async Task<ServiceDetailDto> CreateAsync(ServiceDetailDto home)
    {
        return await sr.AddAsync(home);
    }

    public async Task<IEnumerable<ServiceDetailDto>> GetAsync()
    {
        return await sr.GetAllAsync();
    }

    public async Task<ServiceDetailDto> GetAsync(Guid Tid)
    {
        return await Task.FromResult(sr.GetById(Tid));
    }
}
