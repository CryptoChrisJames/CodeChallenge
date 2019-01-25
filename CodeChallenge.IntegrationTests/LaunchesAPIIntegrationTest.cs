using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using CCLibrary.Services;
using CCLibrary.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using CCLibrary.Models;

namespace CodeChallenge.IntegrationTests
{
    public class LaunchesAPIIntegrationTest
    {
        [Fact]
        public async Task GetLaunches_CallingLaunchesWithGetMethod_ReturnsOK()
        {
            var client = new TestClientProvider()._client;

            var response = await client.GetAsync("/api/Launches");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetLaunch_CallingLaunchesWithGetMethodAndStringAttribute_ReturnsOK()
        {
            var client = new TestClientProvider()._client;

            var response = await client.GetAsync("/api/Launches/stls");

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetLaunches_CallingLaunchesWithGetMethod_ReturnsListOfLaunches()
        {
            var client = new TestClientProvider()._client;

            var response = await client.GetAsync("/api/Launches");
            HttpContent content = response.Content;
            var data = await content.ReadAsStringAsync();
            var launches = JsonConvert.DeserializeObject<List<Launch>>(data);

            var spacex = new SpaceXService(new DefaultHttpClientAccessor().Client, null);

            var result = await spacex.GetLaunches();

            result.Should().BeEquivalentTo(launches);
        }

        [Fact]
        public async Task GetLaunch_CallingLaunchesWithGetMethodAndStringAttribute_ReturnsOneLaunch()
        {
            var client = new TestClientProvider()._client;

            var response = await client.GetAsync("/api/Launches/stls");
            HttpContent content = response.Content;
            var data = await content.ReadAsStringAsync();
            var launch = JsonConvert.DeserializeObject<Launch>(data);

            var spacex = new SpaceXService(new DefaultHttpClientAccessor().Client, null);

            var result = await spacex.GetLaunch("stls");

            result.Should().BeEquivalentTo(launch);
        }
    }
}
