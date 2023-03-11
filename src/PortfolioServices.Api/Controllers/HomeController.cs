using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHomeBo homeBo;

        public HomeController(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;
            homeBo = _serviceProvider.GetService<IHomeBo>();
        }

        // GET: api/<HomeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await homeBo.GetAsync());
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await homeBo.GetAsync(id));
        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HomeDto value)
        {
            return StatusCode(201, await homeBo.CreateAsync(value));
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {            
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
