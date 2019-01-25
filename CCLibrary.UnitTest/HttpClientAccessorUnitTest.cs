using CCLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace CCLibrary.UnitTest
{
    [TestClass]
    public class HttpClientAccessorUnitTest
    {
        [TestMethod]
        public void CreatingHttpClientAccessor_HttpClientIsCreatedWithBaseAddress()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.spacexdata.com/");

            var accessor = new DefaultHttpClientAccessor();

            Assert.AreEqual(client.BaseAddress, accessor.Client.BaseAddress);
        }
    }
}
