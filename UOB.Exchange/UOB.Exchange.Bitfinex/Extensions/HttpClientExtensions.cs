using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UOB.Exchange.Bitfinex.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Parse json object from uri
        /// </summary>
        /// <typeparam name="T">Type of destination object</typeparam>
        /// <param name="httpClient"></param>
        /// <param name="uri">Uri</param>
        /// <returns>Parsed object</returns>
        public static async Task<T> ParseJsonAsync<T>(this HttpClient httpClient, Uri uri)
        {
            var responseString = await httpClient.GetStringAsync(uri);

            return JsonConvert.DeserializeObject<T>(responseString);
        }

    }
}
