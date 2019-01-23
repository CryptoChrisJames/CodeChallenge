using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CCLibrary.Data;

namespace CCLibrary.Services
{
    public class SpaceXService
    {
        private HttpClient _client;
        private ApplicationDbContext _context;

        public SpaceXService(HttpClient client, ApplicationDbContext context)
        {
            _client = client;
            _context = context;
        }

        public async Task<string> GetLaunches()
        {
            var response = await _client.GetAsync("v2/launchpads");
            HttpContent content = response.Content;
            return await content.ReadAsStringAsync();
        }
    }
}
