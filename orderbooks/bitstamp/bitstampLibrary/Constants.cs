namespace UOB.Exchanges.Bitstamp
{
    class Constants
    {
        /// <summary>
        /// Base url to get order list
        /// </summary>
        public const string GET_ORDER_LIST_URL = "https://www.bitstamp.net/api/v2/order_book";

        /// <summary>
        /// Asks list name
        /// </summary>
        public const string ASKS_LIST_NAME = "asks";

        /// <summary>
        /// Bids list name
        /// </summary>
        public const string BIDS_LIST_NAME = "bids";

        /// <summary>
        /// Error key name
        /// </summary>
        public const string ERROR_KEY = "error";

        /// <summary>
        /// Reason key name
        /// </summary>
        public const string REASON_KEY = "reason";

        /// <summary>
        /// Status key name
        /// </summary>
        public const string STATUS_KEY = "status";

        /// <summary>
        /// Timestamp key name
        /// </summary>
        public const string TIMESTAMP_KEY = "timestamp";
    }
}
