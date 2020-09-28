using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BellBoardMockUp.Utilities
{
    public class TJBarnesService
    {
        private readonly HttpClient httpClient;

        public TJBarnesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public HttpClient GetHttpClient()
        {
            return httpClient;
        }
    }

    public class CompLibService
    {
        private readonly HttpClient httpClient;

        public CompLibService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public HttpClient GetHttpClient()
        {
            return httpClient;
        }
    }


}
