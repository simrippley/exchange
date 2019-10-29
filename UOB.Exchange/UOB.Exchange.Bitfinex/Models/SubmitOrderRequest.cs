using Newtonsoft.Json;
using System;

namespace UOB.Exchange.Bitfinex.Models
{
    public partial class SubmitOrderRequest
    {
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("symbol", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Price { get; set; }

        [JsonProperty("amount", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Amount { get; set; }

        [JsonProperty("flags", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Flags { get; set; }

        [JsonProperty("gid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Gid { get; set; }

        [JsonProperty("cid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Cid { get; set; }

        [JsonProperty("lev", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Lev { get; set; }

        [JsonProperty("price_trailing", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PriceTrailing { get; set; }

        [JsonProperty("price_aux_limit", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PriceAuxLimit { get; set; }

        [JsonProperty("price_oco_stop", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int PriceOcoStop { get; set; }

        [JsonProperty("tif", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTimeOffset Tif { get; set; }
    }

}
