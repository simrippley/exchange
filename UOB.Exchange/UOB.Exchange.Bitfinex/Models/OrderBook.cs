namespace UOB.Exchange.Bitfinex.Models
{
    /// <summary>
    /// Order book model
    /// </summary>
    public class OrderBook
    {
        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order period
        /// </summary>
        public float Period { get; set; }

        /// <summary>
        /// Order rate
        /// </summary>
        public float Rate { get; set; }

        /// <summary>
        /// Order count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Order amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Order external id
        /// </summary>
        public int OrderId { get; set; }
    }
}
