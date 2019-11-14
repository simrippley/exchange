using System;
using System.Collections.Generic;
using CriptoExchengLib.Classes;

namespace BinanceCryptoExchengeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BinanceCryptoExchenge bce = new BinanceCryptoExchenge();
            bce.SetAutentification("IYTZ2ugTwRN3FjfGSWc7GXkiR4unBiPhLtTlx31oUWfAnAvmW6VCj8r9fqYO878k", "g4VYUr1TCGfQLNhq0jSAtFCsXbgLww7Xjjd9BFrleFCi1TeRK2DD26WFZdrknCiu");
            List<BaseCurrencyPair> cps = new List<BaseCurrencyPair>();
            BaseCurrencyPair bc = new BaseCurrencyPair("BNBBTC");
            cps.Add(bc);
            bce.GetBookWarrants(cps, 500);
            bce.GetCurrencyPair();
            BinanceOrder bo = new BinanceOrder();
            bo.Pair = new BaseCurrencyPair("LTCBTC");
            bo.Side = BinanceOrderType.Buy;
            bo.Type = BinanceOrderType.Limit;
            bo.Quantity = 1;
            bo.Price = 1;
            bo.TimeInForce = TimeInForce.GTC;
            bce.PostOrder(bo);
            bce.CanselOrder(new BaseCurrencyPair("LTCBTC"), 10);
            bce.GetAccountsList();
            bce.GetOrdersHistory(new BaseCurrencyPair("LTCBTC"), 100);
        }
    }
}
