using CriptoExchengLib.Classes;
using System;
using System.Collections.Generic;
using Xunit;

namespace BinanceCryptoExchengeTests
{
    public class BinanceCryptoExchengeTests
    {
        [Fact]
        public void GetCurrencyPairTest()
        {
            BinanceCryptoExchenge bce = new BinanceCryptoExchenge();
            bce.SetAutentification("IYTZ2ugTwRN3FjfGSWc7GXkiR4unBiPhLtTlx31oUWfAnAvmW6VCj8r9fqYO878k", "g4VYUr1TCGfQLNhq0jSAtFCsXbgLww7Xjjd9BFrleFCi1TeRK2DD26WFZdrknCiu");
            Assert.True(bce.GetCurrencyPair().Count > 0);
        }

        [Fact]
        public void GetBookWarrantsTest()
        {
            BinanceCryptoExchenge bce = new BinanceCryptoExchenge();
            bce.SetAutentification("IYTZ2ugTwRN3FjfGSWc7GXkiR4unBiPhLtTlx31oUWfAnAvmW6VCj8r9fqYO878k", "g4VYUr1TCGfQLNhq0jSAtFCsXbgLww7Xjjd9BFrleFCi1TeRK2DD26WFZdrknCiu");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair bc = new BaseCurrencyPair("BNBBTC");
            cps.Add(bc);
            Assert.True(bce.GetBookWarrants(cps, 100).Count > 0);
        }

        [Fact]
        public void GetAccountsList()
        {
            BinanceCryptoExchenge bce = new BinanceCryptoExchenge();
            bce.SetAutentification("IYTZ2ugTwRN3FjfGSWc7GXkiR4unBiPhLtTlx31oUWfAnAvmW6VCj8r9fqYO878k", "g4VYUr1TCGfQLNhq0jSAtFCsXbgLww7Xjjd9BFrleFCi1TeRK2DD26WFZdrknCiu");
            Assert.True(bce.GetAccountsList().Count > 0);
        }
    }
}
