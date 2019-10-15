using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UOB.Exchange.Bitfinex.Models;
using UOB.Exchange.Bitfinex.Extensions;
using UOB.Exchange.Bitfinex.Core;
using UOB.Exchange.Bitfinex.Enums;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace UOB.Exchange.Bitfinex
{
    /// <summary>
    /// Bitfinex client
    /// </summary>
    public class Bitfinex : IBitfinex
    {
        /// <summary>
        /// todo: вынести в отдельный класс протокол работы с апи
        /// </summary>
        protected HttpClient HttpClient;

        /// <summary>
        /// Public api endpoint
        /// </summary>
        protected readonly Uri PublicBaseUrl;

        /// <summary>
        /// Private api endpoint
        /// </summary>
        protected readonly Uri PrivateBaseUrl;

        /// <summary>
        /// API key
        /// </summary>
        protected string ApiKey { get; set; }

        /// <summary>
        /// Secret key 
        /// </summary>
        protected string SecretKey { get; set; }

        public Bitfinex(string apiKey, string secretKey)
        {
            HttpClient = new HttpClient();

            PublicBaseUrl = new Uri("https://api-pub.bitfinex.com/v2/");
            PrivateBaseUrl = new Uri("https://api.bitfinex.com/v2/auth/w/");

            ApiKey = apiKey;
            SecretKey = secretKey;
        }

        /// <summary>
        /// Get order books of symbol with precision
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>List of order books</returns>
        public async Task<GetOrderBooksResult> GetOrderBooksAsync(GetOrderBooksRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var relativeUri = $"book/{request.FormatedSymbol}/{request.PriceAggregationLevelStringValue}?len={(int)request.Count}";

            var methodUri = new Uri(PublicBaseUrl, relativeUri);

            var responseString = await HttpClient.GetStringAsync(methodUri);

            var ordersJArray = JArray.Parse(responseString);

            var result = new GetOrderBooksResult();

            if (request.PriceAggregationLevel == PriceAggregationLevel.Raw)
            {
                    result.Items = ordersJArray.Select(o => new OrderBook
                    {
                        OrderId = o[0].Value<int>(),
                        Price = o[1].Value<decimal>(),
                        Amount = o[2].Value<decimal>(),
                    });
            }
            else
            {
                switch (request.Type)
                {
                    case OrderBookTypes.Trading:
                        result.Items = ordersJArray.Select(o => new OrderBook
                        {
                            Price = o[0].Value<decimal>(),
                            Count = o[1].Value<int>(),
                            Amount = o[2].Value<decimal>(),
                        });
                        break;

                    case OrderBookTypes.Funding:
                        result.Items = ordersJArray.Select(o => new OrderBook
                        {
                            Rate = o[0].Value<float>(),
                            Period = o[1].Value<float>(),
                            Count = o[2].Value<int>(),
                            Amount = o[3].Value<decimal>(),
                        });
                        break;

                    default:
                        throw new NotImplementedException("Incorrect order type!");
                }
            }
            

            return result;
        }

        /// <summary>
        /// Get symbols
        /// </summary>
        /// <returns>Symbols list</returns>
        public async Task<GetSymbolsResult> GetSymbolsAsync()
        {
            var symbolsPairs = await GetSymbolsPairsAsync();

            IEnumerable<string> symbols = new List<string>();

            foreach (var symbolsPair in symbolsPairs.Items)
            {
                var currentSymbols = new[] { symbolsPair.Substring(0, 3), symbolsPair.Substring(3) };

                symbols = symbols.Union(currentSymbols);
            }

            return new GetSymbolsResult
            {
                Items = symbols,
            };
        }

        /// <summary>
        /// Get symbols pairs
        /// </summary>
        /// <returns>Symbols pairs list</returns>
        public virtual async Task<GetSymbolsResult> GetSymbolsPairsAsync()
        {
            var baseUrl = new Uri("https://api.bitfinex.com/v1/");

            var symbols = await HttpClient.ParseJsonAsync<List<string>>(new Uri(baseUrl, "symbols"));

            var result = new GetSymbolsResult
            {
                Items = symbols,
            };

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<object> CreateOrderAsync(SubmitOrderRequest request)
        {
            var nonce = GetNonce();
            var signature = GetSignature(request, "order/submit", nonce);

            this.HttpClient.DefaultRequestHeaders.Add("bfx-nonce", nonce.ToString());
            this.HttpClient.DefaultRequestHeaders.Add("bfx-apikey", ApiKey);
            this.HttpClient.DefaultRequestHeaders.Add("bfx-signature", signature);

            var bodyString = JObject.FromObject(request).ToString(Formatting.None);
            var stringContent = new StringContent(bodyString, Encoding.UTF8, "application/json");
            var createOrderResult = await
                HttpClient.PostAsync(new Uri(PrivateBaseUrl, "order/submit"), stringContent);

            var content = 
                await createOrderResult.Content.ReadAsStringAsync();

            return content;
        }

        private string GetSignature(object body, string method, ulong nonce)
        {
            var bodyString = JObject.FromObject(body).ToString(Formatting.None);

            var signature = $"/api/v2/auth/w/{method}{nonce}{bodyString}";
            var signatureBytes = Encoding.UTF8.GetBytes(signature);

            var secretKeyBytes = Encoding.UTF8.GetBytes(SecretKey);
            using (var HMACSHA384 = new HMACSHA384(secretKeyBytes))
            using (MemoryStream stream = new MemoryStream(signatureBytes))
            {
                return HMACSHA384.ComputeHash(stream)
                    .Aggregate("", (s, e) => s + string.Format("{0:x2}", e), s => s);
            }

        }

        private ulong GetNonce()
        {
            return ((ulong)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds * 1000000));
        }
    }
}
