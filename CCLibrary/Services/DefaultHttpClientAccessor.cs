using CCLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CCLibrary.Services
{
    //Object used for creating and configuring the HttpClient for the applcation.
    public class DefaultHttpClientAccessor : IHttpClientAccessor
    {
        public HttpClient Client { get; }

        public DefaultHttpClientAccessor()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.spacexdata.com/");
        }
    }
}
