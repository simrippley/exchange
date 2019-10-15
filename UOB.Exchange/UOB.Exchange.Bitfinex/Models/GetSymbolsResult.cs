using System;
using System.Collections.Generic;
using System.Text;

namespace UOB.Exchange.Bitfinex.Models
{
    /// <summary>
    /// Symbols get result model
    /// </summary>
    public class GetSymbolsResult
    {
        /// <summary>
        /// Symbols items
        /// </summary>
        public IEnumerable<string> Items { get; set; }
    }
}
