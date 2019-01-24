﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CCLibrary.Data;
using CCLibrary.Interfaces;
using CCLibrary.Models;
using CCLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        //Class level variables set aside for injection purposes. On the creation of
        //the class, the HttpClient and DbContext can be injected into the SpaceXService.
        
        public HttpClient _client { get; set; }
        public ApplicationDbContext _context { get; set; }
        public SpaceXService _spaceX { get; set; }

        public LaunchesController(IHttpClientAccessor clientAccessor /*, ApplicationDbContext context*/)
        {
            _client = clientAccessor.Client;
            //_context = context;
            _spaceX = new SpaceXService(_client, _context);
        }

        // GET api/Launches - returns all of the current launches
        [HttpGet]
        public async Task<List<Launch>> Get() => await _spaceX.GetLaunches();

        // GET api/Launches/stls - returns launch corresponding to the provided id
        [HttpGet("{id}")]
        public async Task<Launch> Get(string id) => await _spaceX.GetLaunch(id);
        
    }
}
