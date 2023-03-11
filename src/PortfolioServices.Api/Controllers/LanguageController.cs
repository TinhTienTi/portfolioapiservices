using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILanguageBo lBo;

        public LanguageController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.lBo = _serviceProvider.GetService<ILanguageBo>();
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await lBo.GetAsync());
        }

        // GET api/<LanguageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await lBo.GetAsync(id));
        }

        // POST api/<LanguageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LanguageDto value)
        {
            return StatusCode(201, await lBo.CreateAsync(value));
        }

        // PUT api/<LanguageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
