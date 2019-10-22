namespace UOB.Exchanges.Bitstamp.Models
{
    /// <summary>
    /// Class represents an order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Represents an order price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Represents an order amount
        /// </summary>
        public string Amount { get; set; }
    }
}
