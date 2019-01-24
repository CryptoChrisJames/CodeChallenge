using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CCLibrary.Data;
using CCLibrary.Models;
using Newtonsoft.Json;

namespace CCLibrary.Services
{
    public class SpaceXService
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public SpaceXService(HttpClient client, ApplicationDbContext context)
        {
            _client = client;
            _context = context;
        }

        public async Task<List<Launch>> GetLaunches()
        {
            return await GetData();
        }

        public async Task<Launch> GetLaunch(string id)
        {
            var launches = await GetData();
            return launches.Where(l => l.ID == id).FirstOrDefault();
        } 

        private async Task<List<Launch>> GetData()
        {
            if(_context == null)
            {
                var response = await _client.GetAsync("v2/launchpads");
                HttpContent content = response.Content;
                return ParseData(await content.ReadAsStringAsync());
            }
            else
            {
                //var response = await _client.GetAsync("v2/launchpads");
                //HttpContent content = response.Content;
                //await content.ReadAsStringAsync();
                return null;
            }
        }

        private List<Launch> ParseData(string response)
        {
            var launches = JsonConvert.DeserializeObject<List<Launch>>(response);
            var launchnames = JsonConvert.DeserializeObject<List<NameParse>>(response);
            for(int i = 0; i < launches.Count; i++)
            {
                launches[i].Name = launchnames[i].full_name;
            }
            return launches;
        }

        public class NameParse
        {
            public string full_name { get; set; }
        }
    }
}
