using CriptoExchengLib.Classes;
using System;
using System.Collections.Generic;

namespace KrakenCryptoExchengeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("ADACAD");
            cps.Add(cp);
            KrakenCryptoExchenge kc = new KrakenCryptoExchenge();
            kc.SetAutentification("OIav92RTeccxQp4zrM6SH3RN07jEyk3POiPByg/54w1wToBRTtVz3120", "eDxzDp0LL1JQhK+pJF2MYbNz+B/WA203vg76PNtAqnT+zgpURWGO/t/S0aqhO1plyIs3OgNjRaHbk0cwkk6prw==");
            kc.GetCurrencyPair();
            kc.GetBookWarrants(cps, 100);
            KrakenOrder ko = new KrakenOrder();
            ko.Pair = new BaseCurrencyPair("ADACAD");
            ko.Type = KrakenOrderType.Buy;
            ko.Ordertype = KrakenOrderType.Limit;
            ko.Price = 1;
            ko.Quantity = 1;
            kc.PostOrder(ko);
            kc.CanselOrder(10);
            kc.GetOrderStatus(10);
            kc.GetAccountsList();
        }
    }
}
