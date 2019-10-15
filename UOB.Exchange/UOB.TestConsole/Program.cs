using System;
using System.Net.Http;
using System.Threading.Tasks;
using UOB.Exchange.Bitfinex.Core;
using System.Linq;
using UOB.Exchange.Bitfinex.Models;
using UOB.Exchange.Bitfinex;
using UOB.Exchange.Bitfinex.Enums;

namespace UOB.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }


        static async Task MainAsync()
        {
            Console.WriteLine("Bitfinex test starting.");
            Bitfinex bitfinex = 
                new Bitfinex("o3nkwiKsjW9hhBnYgTKOSpNkdiAlog8I3RtwldyF51V", "ghyscnn2JwM2AM4J0iNOjCr7eMrecIKPcVEtDo6Fo8p");

            var btfGetSymbolsResult = await bitfinex.GetSymbolsAsync();
            var btfSymbolsList = btfGetSymbolsResult.Items.ToList();

            Console.WriteLine($"Geting symbols count = {btfSymbolsList.Count}");

            var request = new GetOrderBooksRequest(btfSymbolsList[0], 
                PriceAggregationLevel.Raw, 
                OrderBooksGettingCount.OneHundred, 
                OrderBookTypes.Funding);

            var btfGetOrderBooksResult = await bitfinex.GetOrderBooksAsync(request);
            var sd = await bitfinex.CreateOrderAsync(new SubmitOrderRequest
            {
                Type = "EXCHANGE LIMIT",
                Symbol = "tBTCUSD",
                Price = "1",
                Amount = "0.001",
                Flags = 0
            });

            Console.WriteLine($"Geting orders of symbol = {btfSymbolsList[0]} with precision = P0. Count = {btfGetOrderBooksResult.Items.Count()}");

            Console.WriteLine("Bitfinex end test.");

            Console.Read();
        }
    }
}
