using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UOB.Exchanges.Bitstamp.Models;
using System.Collections.Generic;
using UOB.Exchanges.Bitstamp.Builders;

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
        /// Method to set headers for requests authentication
        /// </summary>
        /// <param name="builder">Builder to create message for signing request</param>
        private async Task SetHeaders(MessageBuilder builder)
        {
            await Task.Run(() =>
            {
                _httpClient.DefaultRequestHeaders.Clear();
                var _message = builder.SignatureMessage;
                _httpClient.DefaultRequestHeaders.Add(Constants.X_AUTH_HEADER_KEY, string.Format("{0} {1}", Constants.BITSTAMP_VALUE, _message.ApiKey));
                _httpClient.DefaultRequestHeaders.Add(Constants.X_AUTH_SIGNATURE_KEY, Helpers.GetHmac256(_message.ToString()));
                _httpClient.DefaultRequestHeaders.Add(Constants.X_AUTH_NONCE_KEY, _message.Nonce);
                _httpClient.DefaultRequestHeaders.Add(Constants.X_AUTH_TIMESTAMP_KEY, _message.Timestamp);
                _httpClient.DefaultRequestHeaders.Add(Constants.X_AUTH_VERSION_KEY, _message.AuthVersion);
            });
        }
    }
}
