using CriptoExchengLib.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ExmoCryptoExchengeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ExmoCryptoExchenge ex = new ExmoCryptoExchenge();
            ex.SetAutentification("K-d1b145144afec7e52afd98ab18fcdd3b5d9ce6c8", "S-b457848406b1cebaa503782234048dade4e92e42");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair cp = new BaseCurrencyPair("BTC_USD");
            cps.Add(cp);
            ex.GetCurrencyPair();
            BaseOrder bo = new BaseOrder();
            bo.Pair = new BaseCurrencyPair("BTC_USD");
            bo.Price = 0;
            bo.Quantity = 0;
            bo.Type = BaseOrderType.Buy;
            ex.PostOrder(bo);
            ex.GetOrderStatus(12345);
            ex.GetAccountsList();
            ex.GetHistoryRecords(DateTime.Now);
            ex.GetOrdersHistory(cp, 100);
            string json = JsonConvert.SerializeObject(ex.GetBookWarrants(cps, 10), Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
