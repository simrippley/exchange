using System;
using UOB.Exchanges.Bitstamp;

namespace bitstampApp
{
    /// <summary>
    /// Class to represent library work
    /// </summary>
    class Program
    {
        /// <summary>
        /// Represents library class
        /// </summary>
        static Library _library;

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main(string[] args)
        {
            _library = new Library();
            //ShowOrderListDataByCurrencyPair();
            ShowListOfTradingPairs();
        }

        /// <summary>
        /// Method to show list of orders by currency pair on console
        /// </summary>
        static void ShowOrderListDataByCurrencyPair()
        {
            var _result = _library.GetOrderListByCurrencyPair(CurrencyPairs.bchbtc).Result;
            Console.WriteLine("Timestamp: {0}; Asks count: {1}; Bids count: {2}", _result.Timestamp, _result.Asks.Count, _result.Bids.Count);
            Console.ReadLine();
        }

        /// <summary>
        /// Method to show list all trading pairs on console
        /// </summary>
        static void ShowListOfTradingPairs()
        {
            var _result = _library.GetCurrencyPairs().Result;
            foreach(var _tradePair in _result)
            {
                Console.WriteLine(_tradePair.Name);
            }
            Console.ReadLine();
        }
    }
}
