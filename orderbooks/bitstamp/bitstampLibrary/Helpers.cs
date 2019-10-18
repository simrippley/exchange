using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UOB.Exchanges.Bitstamp.Models;

namespace UOB.Exchanges.Bitstamp
{
    /// <summary>
    /// Static helper class
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get orders from root object by specified list name
        /// </summary>
        /// <param name="root">Root object</param>
        /// <param name="listName">List name, what we'd like to get from root</param>
        /// <returns>List of orders</returns>
        public static IList<Order> GetOrders(JObject root, string listName)
        {
            IList<Order> _orders = new List<Order>();
            JArray _ordersAsListOfStrings = (JArray)root[listName];
            for (int i = 0; i < _ordersAsListOfStrings.Count; i++)
            {
                JArray item = (JArray)_ordersAsListOfStrings[i];
                var order = new Order { Amount = (string)item[0], Price = (string)item[1] };
                _orders.Add(order);
            }
            return _orders;
        }

        /// <summary>
        /// Library, to make requests to Bitstamp rest api
        /// </summary>
        /// <param name="currencyPairs">Currency pairs</param>
        /// <returns>Url to get order list with specified currency pair</returns>
        public static string GetOrderListUrl(CurrencyPairs currencyPairs)
        {
            var url = string.Format("{0}/{1}", Constants.GET_ORDER_LIST_URL, currencyPairs);
            return url;
        }
    }
}
