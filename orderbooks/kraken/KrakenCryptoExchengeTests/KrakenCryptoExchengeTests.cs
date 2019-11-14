using System;
using Xunit;
using CriptoExchengLib.Classes;
using System.Collections.Generic;

namespace KrakenCryptoExchengeTests
{
    public class KrakenCryptoExchengeTests
    {
        [Fact]
        public void GetCurrencyPairTest()
        {
            KrakenCryptoExchenge kc = new KrakenCryptoExchenge();
            kc.SetAutentification("OIav92RTeccxQp4zrM6SH3RN07jEyk3POiPByg/54w1wToBRTtVz3120", "eDxzDp0LL1JQhK+pJF2MYbNz+B/WA203vg76PNtAqnT+zgpURWGO/t/S0aqhO1plyIs3OgNjRaHbk0cwkk6prw==");
            Assert.True(kc.GetCurrencyPair().Count > 0);
        }

        [Fact]
        public void GetBookWarrantsTest()
        {
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("ADACAD");
            cps.Add(cp);
            KrakenCryptoExchenge kc = new KrakenCryptoExchenge();
            kc.SetAutentification("OIav92RTeccxQp4zrM6SH3RN07jEyk3POiPByg/54w1wToBRTtVz3120", "eDxzDp0LL1JQhK+pJF2MYbNz+B/WA203vg76PNtAqnT+zgpURWGO/t/S0aqhO1plyIs3OgNjRaHbk0cwkk6prw==");
            Assert.True(kc.GetBookWarrants(cps, 100).Count > 0);
        }

        [Fact]
        public void GetAccountsList()
        {
            KrakenCryptoExchenge kc = new KrakenCryptoExchenge();
            kc.SetAutentification("OIav92RTeccxQp4zrM6SH3RN07jEyk3POiPByg/54w1wToBRTtVz3120", "eDxzDp0LL1JQhK+pJF2MYbNz+B/WA203vg76PNtAqnT+zgpURWGO/t/S0aqhO1plyIs3OgNjRaHbk0cwkk6prw==");
            Assert.True(kc.GetAccountsList().Count > 0);
        }
    }
}
