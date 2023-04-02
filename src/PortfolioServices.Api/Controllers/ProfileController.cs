using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Utilities;

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProfileBo profileBo;

        public ProfileController(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
            profileBo = _serviceProvider.GetService<IProfileBo>();
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            try
            {
                return Ok(await profileBo.GetHomeInfoQueryableAsync(LanguageCodeConstants.VIET_NAM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(nameof(About))]
        public async Task<IActionResult> About()
        {
            try
            {
                return Ok(await profileBo.GetAboutInfoQueryableAsync(LanguageCodeConstants.VIET_NAM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(nameof(Client))]
        public async Task<IActionResult> Client()
        {
            try
            {
                return Ok(await profileBo.GetClientInfoQueryableAsync(LanguageCodeConstants.VIET_NAM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(nameof(Portfolio))]
        public async Task<IActionResult> Portfolio()
        {
            try
            {
                return Ok(await profileBo.GetPortfolioInfoQueryableAsync(LanguageCodeConstants.VIET_NAM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(nameof(Service))]
        public async Task<IActionResult> Service()
        {
            try
            {
                return Ok(await profileBo.GetServiceInfoQueryableAsync(LanguageCodeConstants.VIET_NAM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
