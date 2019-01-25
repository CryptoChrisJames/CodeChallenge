using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CodeChallenge.IntegrationTests
{
    public class TestClientProvider
    {
        public HttpClient _client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            _client = server.CreateClient();
        }
    }
}
