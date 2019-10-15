using System.Collections.Generic;

namespace UOB.Exchange.Bitfinex.Models
{
    /// <summary>
    /// Order book get result model
    /// </summary>
    public class GetOrderBooksResult
    {
        public GetOrderBooksResult()
        {
            Items = new List<OrderBook>();
        }

        /// <summary>
        /// Order books items
        /// </summary>
        public IEnumerable<OrderBook> Items { get; set; }
    }
}
