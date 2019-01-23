using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CCLibrary.Interfaces
{
    //Interface created for abstracting HttpClient access.
    public interface IHttpClientAccessor
    {
        HttpClient Client { get; }
    }
}
