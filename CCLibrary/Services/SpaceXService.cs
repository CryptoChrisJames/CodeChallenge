using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CCLibrary.Data;
using CCLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CCLibrary.Services
{
    public class SpaceXService
    {
        //Class level variables for the SpaceXService injected from the controller.
        //The availability of both the DbContext and HttpClient gives the class the ability to 
        //retrieve the necessary data from either sources without impacting the rest of the application. 

        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public SpaceXService(HttpClient client, ApplicationDbContext context)
        {
            _client = client;
            _context = context;
        }

        //Returns all launches. 
        public async Task<List<Launch>> GetLaunches()
        {
            return await GetData();
        }

        //Returns a launch by the id. 
        public async Task<Launch> GetLaunch(string id)
        {
            var launches = await GetData();
            return launches.Where(l => l.ID == id).FirstOrDefault();
        } 

        //Retrieves the data from the appropriate source. If the Db context is
        //provided, then the function will pull the data from it. Otherwise, it will call the 
        //SpaceX API with the Http Client.
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
                return _context.Launches.ToList();
            }
        }

        //Parses the JSON response from the API and populates the Name field of the data model. 
        private List<Launch> ParseData(string response)
        {
            var launches = JsonConvert.DeserializeObject<List<Launch>>(response);
            var launchnames = JsonConvert.DeserializeObject<List<NameParse>>(response);
            for(int i = 0; i < launches.Count; i++)
            {
                launches[i].Name = launchnames[i].Full_name;
            }
            return launches;
        }

        //Auxillary nested class for retrieving the full_name object from the 
        //JSON response. 
        public class NameParse
        {
            public string Full_name { get; set; }
        }
    }
}
