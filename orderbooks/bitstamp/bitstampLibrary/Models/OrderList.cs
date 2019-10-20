using System.Collections.Generic;

namespace UOB.Exchanges.Bitstamp.Models
{
    /// <summary>
    /// Class represents a json response of  https://www.bitstamp.net/api/v2/order_book/{currency_pair}/
    /// </summary>
    public class OrderList
    {
        /// <summary>
        /// Represents a request time as timestamp
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Represents a list of bids orders
        /// </summary>
        public IList<Order> Bids { get; set; }

        /// <summary>
        /// Represents a list of asks orders
        /// </summary>
        public IList<Order> Asks { get; set; }

        /// <summary>
        /// Represents the reason for the error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Represents the error status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Represents the error reason
        /// </summary>
        public string Reason { get; set; }
    }
}
