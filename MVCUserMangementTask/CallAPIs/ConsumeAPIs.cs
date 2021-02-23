using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MVCUserMangementTask.CallAPIs
{
    public class ConsumeAPIs
    {
        private static string Baseurl = "https://localhost:44372/";
        public static HttpClient GetClient(string apiPath)
        {
            HttpClientHandler handler = new HttpClientHandler();
            var client = new HttpClient(handler, false);
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
