using System.Configuration;
using System.Net.Http;
using UOB.Exchanges.Bitstamp.Models;

namespace UOB.Exchanges.Bitstamp.Builders
{
    /// <summary>
    /// Builder to create a message object for requests signing
    /// </summary>
    public class MessageBuilder
    {
        /// <summary>
        /// Signature message object
        /// </summary>
        protected SignatureMessage _signatureMessage = new SignatureMessage();

        /// <summary>
        /// Set Api key
        /// </summary>
        /// <returns>Current instance/returns>
        protected virtual MessageBuilder SetApiKey()
        {
            _signatureMessage.ApiKey = ConfigurationManager.AppSettings["apiKey"];
            return this;
        }

        /// <summary>
        /// Set Auth Version
        /// </summary>
        /// <returns>Current instance/returns>
        protected virtual MessageBuilder SetAuthVersion()
        {
            _signatureMessage.AuthVersion = Constants.X_AUTH_VERSION_VALUE;
            return this;
        }

        /// <summary>
        /// Set Nonce value
        /// </summary>
        /// <returns>Current instance/returns>
        private MessageBuilder SetNonce()
        {
            _signatureMessage.Nonce = Helpers.GetNonce();
            return this;
        }

        /// <summary>
        /// Set Timestamp
        /// </summary>
        /// <returns>Current instance/returns>
        private MessageBuilder SetTimestamp()
        {
            _signatureMessage.Timestamp = Helpers.GetTimestamp();
            return this;
        }

        /// <summary>
        /// Set api host
        /// </summary>
        /// <returns>Current instance/returns>
        protected MessageBuilder SetHost()
        {
            _signatureMessage.Host = Constants.HOST;
            return this;
        }

        /// <summary>
        /// Set Http method
        /// </summary>
        /// <returns>Current instance/returns>
        protected virtual MessageBuilder SetMethod()
        {
            _signatureMessage.HttpVerb = HttpMethod.Post.Method;
            return this;
        }

        /// <summary>
        /// Set Content type
        /// </summary>
        /// <returns>Current instance/returns>
        protected virtual MessageBuilder SetContentType()
        {
            _signatureMessage.ContentType = Constants.CONTENT_TYPE_VALUE;
            return this;
        }

        /// <summary>
        /// Set request body
        /// </summary>
        /// <param name="requestBody">Body request</param>
        /// <returns>Current instance/returns>
        public MessageBuilder SetRequestBody(string requestBody)
        {
            _signatureMessage.RequestBody = requestBody;
            return this;
        }

        /// <summary>
        /// Set HTTP request path
        /// </summary>
        /// <param name="path">HTTP request path</param>
        /// <returns>Current instance/returns>
        public MessageBuilder SetPath(string path)
        {
            _signatureMessage.Path = path;
            return this;
        }

        /// <summary>
        /// Set any query parameters
        /// </summary>
        /// <param name="query">Query params</param>
        /// <returns>Current instance/returns>
        public MessageBuilder SetQuery(string query)
        {
            _signatureMessage.Query = query;
            return this;
        }

        /// <summary>
        /// Set required properties
        /// </summary>
        /// <returns>Current instance/returns>
        public virtual MessageBuilder Build()
        {
            SetApiKey().SetAuthVersion().SetContentType().SetHost().SetMethod().SetNonce().SetTimestamp();
            return this;
        }

        /// <summary>
        /// Get result signature message object
        /// </summary>
        /// <returns>Signature message object/returns>
        public SignatureMessage SignatureMessage
        {
            get
            {
                return _signatureMessage;
            }
        }
    }
}
