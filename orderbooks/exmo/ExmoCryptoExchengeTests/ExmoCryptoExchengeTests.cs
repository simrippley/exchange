using CriptoExchengLib.Classes;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExmoCryptoExchengeTests
{
    public class ExmoCryptoExchengeTests
    {
        [Fact]
        public void GetCurrencyPairTest()
        {
            ExmoCryptoExchenge ex = new ExmoCryptoExchenge();
            ex.SetAutentification("K-d1b145144afec7e52afd98ab18fcdd3b5d9ce6c8", "S-b457848406b1cebaa503782234048dade4e92e42");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("BTC_USD");
            cps.Add(cp);
            ;
            Assert.True(ex.GetCurrencyPair().Count>0);
        }

        [Fact]
        public void GetBookWarrantsTest()
        {
            ExmoCryptoExchenge ex = new ExmoCryptoExchenge();
            ex.SetAutentification("K-d1b145144afec7e52afd98ab18fcdd3b5d9ce6c8", "S-b457848406b1cebaa503782234048dade4e92e42");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("BTC_USD");
            cps.Add(cp);
            Assert.True(ex.GetBookWarrants(cps,100).Count > 0);
        }

        [Fact]
        public void GetAccountsList()
        {
            ExmoCryptoExchenge ex = new ExmoCryptoExchenge();
            ex.SetAutentification("K-d1b145144afec7e52afd98ab18fcdd3b5d9ce6c8", "S-b457848406b1cebaa503782234048dade4e92e42");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("BTC_USD");
            cps.Add(cp);
            Assert.True(ex.GetAccountsList().Count > 0);
        }
    }
}
