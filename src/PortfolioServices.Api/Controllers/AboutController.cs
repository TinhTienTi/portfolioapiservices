using Microsoft.AspNetCore.Mvc;
using PortfolioServices.Api.Bo.Interfaces;
using PortfolioServices.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAboutBo abo;

        public AboutController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this.abo = serviceProvider.GetService<IAboutBo>();
        }


        // GET: api/<AboutController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await abo.GetAsync());
        }

        // GET api/<AboutController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await abo.GetAsync(id));
        }

        // POST api/<AboutController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AboutDto value)
        {
            return StatusCode(201, await abo.CreateAsync(value));
        }

        // PUT api/<AboutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AboutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
