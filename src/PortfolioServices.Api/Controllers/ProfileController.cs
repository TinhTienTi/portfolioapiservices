using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo.Interfaces;

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
                return Ok(await profileBo.GetHomeInfoQueryableAsync("vi"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
