using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UOB.Exchanges.Bitstamp.Models;
using System.Collections.Generic;

namespace UOB.Exchanges.Bitstamp
{
    /// <summary>
    /// Currency pairs constants
    /// </summary>
    public enum CurrencyPairs { btcusd, btceur, eurusd, xrpusd, xrpeur, xrpbtc, ltcusd, ltceur, ltcbtc, ethusd, etheur, ethbtc, bchusd, bcheur, bchbtc };

    /// <summary>
    /// Library, to make requests to Bitstamp rest api
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Http client, helps to make requests
        /// </summary>
        private readonly HttpClient _httpClient = new HttpClient();


        /// <summary>
        /// Async method to get list of orders by currency pair
        /// </summary>
        /// <param name="currencyPairs">Currency pair</param>
        /// <returns>Order list object, that contains timestamp, asks and bids lists (if there is an error - error info)</returns>
        public async Task<OrderList> GetOrderListByCurrencyPair(CurrencyPairs currencyPairs)
        {
            var _response = await _httpClient.GetStringAsync(Helpers.GetRequestUrl(Constants.API_V2_URL, 
                                                                                    Constants.GET_ORDER_LIST_ACTION,
                                                                                    currencyPairs.ToString()));          
            JObject _root = JObject.Parse(_response);
            var _orderList = new OrderList
            {
                Asks = Helpers.GetOrders(_root, Constants.ASKS_LIST_NAME),
                Bids = Helpers.GetOrders(_root, Constants.BIDS_LIST_NAME),
                Error = _root[Constants.ERROR_KEY]?.ToString(),
                Reason = _root[Constants.REASON_KEY]?.ToString(),
                Status = _root[Constants.STATUS_KEY]?.ToString(),
                Timestamp = _root[Constants.TIMESTAMP_KEY].ToString()
            };
            return _orderList;
        }

        /// <summary>
        /// Method to get headers to authenticate requests
        /// </summary>
        /// <param name="signatureMessage">Object, what contains different requests data</param>
        /// /// <param name="secretKey">App secret key to sign message</param>
        /// <returns>Dictionary of headers to make auth request</returns>
        private async Task<IDictionary<string, string>> GetHeaders(SignatureMessage signatureMessage, string secretKey)
        {
            var task = await Task.Run(() =>
            {
                var _signature = Helpers.GetHmac256(signatureMessage.ToString(), secretKey);
                var _headers = new Dictionary<string, string>
                {
                    { Constants.X_AUTH_HEADER_KEY, string.Format("{0} {1}", Constants.BITSTAMP_VALUE, signatureMessage.ApiKey)},
                    { Constants.X_AUTH_SIGNATURE_KEY, _signature },
                    { Constants.X_AUTH_NONCE_KEY, signatureMessage.Nonce },
                    { Constants.X_AUTH_TIMESTAMP_KEY, signatureMessage.Timestamp },
                    { Constants.X_AUTH_VERSION_KEY, signatureMessage.AuthVersion },
                    { Constants.CONTENT_TYPE_KEY, signatureMessage.ContentType },
                };
                return _headers;
            });
            return task;
        }
    }
}
