using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Whoisvisiting.ClearbitService
{
    public static class WebClient
    {
        static HttpClient _client = new HttpClient();

        public static async Task<string> GetAsync(string resourceUrl, string apiKey)
        {
            var httpResponce = await TryGetAsync(resourceUrl, apiKey);

            if (httpResponce.StatusCode == HttpStatusCode.Accepted)
            {
                Task.Delay(2000).Wait();

                httpResponce = await TryGetAsync(resourceUrl, apiKey);
            }

            if (httpResponce.StatusCode == HttpStatusCode.OK)
            {
                return await httpResponce.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        private static async Task<HttpResponseMessage> TryGetAsync(string resourceUrl, string apiKey)
        {
            // not good, store in secure location
            var basicAuthHeader = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        ASCIIEncoding.ASCII.GetBytes(
                           $"{apiKey}:")));

            _client.DefaultRequestHeaders.Authorization = basicAuthHeader;

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

           return await _client.GetAsync(resourceUrl);
        }
    }

   
}
