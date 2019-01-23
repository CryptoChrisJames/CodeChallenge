using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CCLibrary.Data;
using CCLibrary.Interfaces;
using CCLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        public HttpClient _client { get; set; }
        public ApplicationDbContext _context { get; set; }
        public SpaceXService _spaceX { get; set; }

        public LaunchesController(IHttpClientAccessor clientAccessor /*, ApplicationDbContext context*/)
        {
            _client = clientAccessor.Client;
            //_context = context;
            _spaceX = new SpaceXService(_client, _context);
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get() => await _spaceX.GetLaunches();

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
