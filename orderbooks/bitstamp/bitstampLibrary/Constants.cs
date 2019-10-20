namespace UOB.Exchanges.Bitstamp
{
    /// <summary>
    /// Class contains a list of library constants
    /// </summary>
    class Constants
    {
        /// <summary>
        /// Base API v2 url
        /// </summary>
        public const string API_V2_URL = "https://www.bitstamp.net/api/v2";

        /// <summary>
        /// Action to get order list
        /// </summary>
        public const string GET_ORDER_LIST_ACTION = "order_book";

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

        /// <summary>
        /// X-Auth header key
        /// </summary>
        public const string X_AUTH_HEADER_KEY = "X-Auth";

        /// <summary>
        /// Bitstamp value
        /// </summary>
        public const string BITSTAMP_VALUE = "BITSTAMP";

        /// <summary>
        /// X-Auth-Signature key
        /// </summary>
        public const string X_AUTH_SIGNATURE_KEY = "X-Auth-Signature";

        /// <summary>
        /// X-Auth-Nonce key
        /// </summary>
        public const string X_AUTH_NONCE_KEY = "X-Auth-Nonce";

        /// <summary>
        /// X-Auth-Timestamp key
        /// </summary>
        public const string X_AUTH_TIMESTAMP_KEY = "X-Auth-Timestamp";

        /// <summary>
        /// X-Auth-Version key
        /// </summary>
        public const string X_AUTH_VERSION_KEY = "X-Auth-Version";

        /// <summary>
        /// X-Auth-Version value
        /// </summary>
        public const string X_AUTH_VERSION_VALUE = "v2";

        /// <summary>
        /// Content-Type key
        /// </summary>
        public const string CONTENT_TYPE_KEY = "Content-Type";

        /// <summary>
        /// Content-Type value
        /// </summary>
        public const string CONTENT_TYPE_VALUE = "application/x-www-form-urlencoded";
    }
}
