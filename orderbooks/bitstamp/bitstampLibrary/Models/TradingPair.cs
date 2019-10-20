
namespace UOB.Exchanges.Bitstamp
{
    /// <summary>
    /// Class represents a trading pair
    /// </summary>
    public class TradingPair
    {
        /// <summary>
        /// Trading pair.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL symbol of trading pair.
        /// </summary>
        public string UrlSymbol { get; set; }

        /// <summary>
        /// Decimal precision for base currency (BTC/USD - base: BTC).
        /// </summary>
        public int BaseDecimals { get; set; }

        /// <summary>
        /// Decimal precision for counter currency (BTC/USD - counter: USD).
        /// </summary>
        public int CounterDecimals { get; set; }

        /// <summary>
        /// Minimum order size.
        /// </summary>
        public string MinimumOrder { get; set; }

        /// <summary>
        /// Trading engine status (Enabled/Disabled).
        /// </summary>
        public string Trading { get; set; }

        /// <summary>
        /// Trading pair description.
        /// </summary>
        public string Description { get; set; }
    }
}
