using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.May2020.Data.RestClient
{
    /// <summary>
    ///     Contains generic methods for RESTful communication using JSON format.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        ///     Sends a Get request to a specified URL
        /// </summary>
        /// <param name="url">Request URL</param>
        /// <returns>Http response messages</returns>
        Task<HttpResponseMessage> GetAsync(string url);
    }
}