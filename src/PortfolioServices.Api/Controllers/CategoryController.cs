using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICategoryBo cbo;

        public CategoryController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.cbo = _serviceProvider.GetService<ICategoryBo>();
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cbo.GetAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await cbo.GetAsync(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriesDto value)
        {
            return StatusCode(201, await cbo.CreateAsync(value));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
