using System.Configuration;
using System.Net.Http;
using UOB.Exchanges.Bitstamp.Models;

namespace UOB.Exchanges.Bitstamp.Builders
{
    public class MessageBuilder
    {
        protected SignatureMessage _signatureMessage = new SignatureMessage();

        protected virtual MessageBuilder SetApiKey()
        {
            _signatureMessage.ApiKey = ConfigurationManager.AppSettings["apiKey"];
            return this;
        }

        protected virtual MessageBuilder SetAuthVersion()
        {
            _signatureMessage.AuthVersion = Constants.X_AUTH_VERSION_VALUE;
            return this;
        }

        private MessageBuilder SetNonce()
        {
            _signatureMessage.Nonce = Helpers.GetNonce();
            return this;
        }

        private MessageBuilder SetTimestamp()
        {
            _signatureMessage.Timestamp = Helpers.GetTimestamp();
            return this;
        }

        protected MessageBuilder SetHost()
        {
            _signatureMessage.Host = Constants.HOST;
            return this;
        }

        protected virtual MessageBuilder SetMethod()
        {
            _signatureMessage.HttpVerb = HttpMethod.Post.Method;
            return this;
        }

        protected virtual MessageBuilder SetContentType()
        {
            _signatureMessage.ContentType = Constants.CONTENT_TYPE_VALUE;
            return this;
        }

        public MessageBuilder SetRequestBody(string requestBody)
        {
            _signatureMessage.RequestBody = requestBody;
            return this;
        }

        public MessageBuilder SetPath(string path)
        {
            _signatureMessage.Path = path;
            return this;
        }

        public MessageBuilder SetQuery(string query)
        {
            _signatureMessage.Query = query;
            return this;
        }

        public virtual MessageBuilder Build()
        {
            SetApiKey().SetAuthVersion().SetContentType().SetHost().SetMethod().SetNonce().SetTimestamp();
            return this;
        }

        public SignatureMessage SignatureMessage
        {
            get
            {
                return _signatureMessage;
            }
        }
    }
}
