namespace UOB.Exchanges.Bitstamp.Models
{
    /// <summary>
    /// Model, what represents data required for signature 
    /// </summary>
    public struct SignatureMessage
    {
        /// <summary>
        /// App api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The HTTP (uppercase) verb. Example: "GET", "POST"
        /// </summary>
        public string HttpVerb { get; set; }

        /// <summary>
        /// The hostname (lowercase), matching the HTTP "Host" request header field (including any port number).
        /// Example: "www.bitstamp.net"
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// The HTTP request path with leading slash. 
        /// Example: "/api/v2/balance/"
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Any query parameters or empty string. This should be the exact string sent by the client, including urlencoding. 
        /// Example: "?limit=100&sort=asc"
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Example: "application/x-www-form-urlencoded"
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Client generated random nonce:
        /// - lowercase,
        /// - 36 char string,
        /// - each nonce can be used only once within a timeframe of 150 seconds.
        /// Example: "f93c979d-b00d-43a9-9b9c-fd4cd9547fa6"
        /// </summary>
        public string Nonce { get; set; }

        /// <summary>
        /// Request departure timestamp UTC in milliseconds. 
        /// If timestamp is more than 150 seconds from current server time, it will not allow to make the request.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Example: "v2"
        /// </summary>
        public string AuthVersion { get; set; }

        /// <summary>
        /// Body of request
        /// </summary>
        public string RequestBody { get; set; }


        /// <summary>
        /// Overriden ToString() method to make a string of all the object params
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} {1}/{2}{3}/{4}/{5}/{6}/{7}/{8}/{9}",
                Constants.BITSTAMP_VALUE, ApiKey, HttpVerb, Host, Path, Query, ContentType, Nonce, Timestamp,
                AuthVersion, RequestBody);
        }
    }
}
