using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
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
                JArray _item = (JArray)_ordersAsListOfStrings[i];
                var _order = new Order { Amount = (string)_item[0], Price = (string)_item[1] };
                _orders.Add(_order);
            }
            return _orders;
        }

        /// <summary>
        /// Get url to make a request to REST api
        /// </summary>
        /// <param name="apiUrl">Base api url (different versions could be)</param>
        /// <param name="action">Action of the request</param>
        /// <param name="parameters">Request parameters</param>
        /// <returns>Url to make a request</returns>
        public static string GetRequestUrl(string apiUrl, string action, params string[] parameters)
        {
            StringBuilder _builder = new StringBuilder(string.Format("{0}/{1}", apiUrl, action));
            if (parameters.Length > 0)
            {
                foreach (var _param in parameters)
                {
                    _builder.Append(string.Format("/{0}", _param));
                }
            }
            return _builder.ToString();
        }
    }
}
