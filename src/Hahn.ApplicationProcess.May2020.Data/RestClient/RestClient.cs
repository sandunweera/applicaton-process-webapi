using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.May2020.Data.RestClient
{
    /// <summary>
    ///     IRestClient implementation using HTTPClient.
    /// </summary>
    public class RestClient : IRestClient
    {
        private readonly HttpClient _client;

        public RestClient()
        {
            _client = new HttpClient();
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}