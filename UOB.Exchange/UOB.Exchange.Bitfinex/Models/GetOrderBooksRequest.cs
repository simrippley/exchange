using System;
using System.Collections.Generic;
using UOB.Exchange.Bitfinex.Enums;

namespace UOB.Exchange.Bitfinex.Models
{
    /// <summary>
    /// Order books get request model
    /// </summary>
    public class GetOrderBooksRequest
    {
        /// <summary>
        /// Type of order book
        /// </summary>
        public OrderBookTypes Type { get; set; }

        /// <summary>
        /// String value for price aggregation level. 
        /// Using in API requests
        /// </summary>
        public string PriceAggregationLevelStringValue =>
            PriceAggregationLevelsToStringValue[PriceAggregationLevel];

        /// <summary>
        /// Formated symbol/symbol pairs
        /// </summary>
        public string FormatedSymbol => $"{OrderBookTypeStringValue}{Symbol}";

        /// <summary>
        /// Price aggregation level
        /// </summary>
        public PriceAggregationLevel PriceAggregationLevel { get; set; }

        /// <summary>
        /// Count of recieved order books
        /// </summary>
        public OrderBooksGettingCount Count { get; set; }

        /// <summary>
        /// Symbol/symbol pairs   
        /// </summary>
        protected string Symbol { get; set; }

        /// <summary>
        /// Order book type string value. 
        /// Using in API requests
        /// </summary>
        protected string OrderBookTypeStringValue => OrderBookTypesToStringValue[Type];
        
        /// <summary>
        /// Linking dictionary for geting price aggregation level string value
        /// </summary>
        protected IDictionary<PriceAggregationLevel, string> PriceAggregationLevelsToStringValue;

        /// <summary>
        /// Linking dictionary for geting order book type string value
        /// </summary>
        protected IDictionary<OrderBookTypes, string> OrderBookTypesToStringValue;


        public GetOrderBooksRequest(string symbol, PriceAggregationLevel precision, OrderBooksGettingCount count, OrderBookTypes type)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            Symbol = symbol.Trim().ToUpper(); 

            Type = type;
            PriceAggregationLevel = precision;
            Count = count;

            PriceAggregationLevelsToStringValue = new Dictionary<PriceAggregationLevel, string>
            {
                { PriceAggregationLevel.Zero, "P0" },
                { PriceAggregationLevel.One, "P1" },
                { PriceAggregationLevel.Two, "P2" },
                { PriceAggregationLevel.Three, "P3" },
                { PriceAggregationLevel.Four, "P4" },

                { PriceAggregationLevel.Raw, "R0" },
            };

            OrderBookTypesToStringValue = new Dictionary<OrderBookTypes, string>
            {
                { OrderBookTypes.Funding, "f" },
                { OrderBookTypes.Trading, "t" },
            };
        }



    }
}
