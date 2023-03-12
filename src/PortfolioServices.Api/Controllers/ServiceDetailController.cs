using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceDetailController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceDetailBo sbo;

        public ServiceDetailController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            sbo = _serviceProvider.GetService<IServiceDetailBo>();
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await sbo.GetAsync());
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await sbo.GetAsync(id));
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceDetailDto value)
        {
            return StatusCode(201, await sbo.CreateAsync(value));
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
