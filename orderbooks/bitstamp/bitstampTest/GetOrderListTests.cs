using NUnit.Framework;
using UOB.Exchanges.Bitstamp;
using UOB.Exchanges.Bitstamp.Models;

namespace bitstampTests
{
    /// <summary>
    /// Class represents a list of tests
    /// </summary>
    public class GetOrderListTests
    {
        /// <summary>
        /// Represents library class
        /// </summary>
        private Library _library;

        /// <summary>
        /// Represents Order list object
        /// </summary>
        private OrderList _orderList;

        /// <summary>
        /// Represents basic setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        /// <summary>
        /// Check getting order list by bchbtc currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_bchbtc_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.bchbtc).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by bcheur currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_bcheur_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.bcheur).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by bchusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_bchusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.bchusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by btceur currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_btceur_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.btceur).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by btcusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_btcusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.btcusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by ethbtc currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_ethbtc_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.ethbtc).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by etheur currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_etheur_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.etheur).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by ethusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_ethusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.ethusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by eurusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_eurusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.eurusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by ltcbtc currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_ltcbtc_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.ltcbtc).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by ltceur currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_ltceur_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.ltceur).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by ltcusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_ltcusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.ltcusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by xrpbtc currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_xrpbtc_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.xrpbtc).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by xrpeur currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_xrpeur_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.xrpeur).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Check getting order list by xrpusd currency pair
        /// </summary>
        [Test]
        public void GetOrderListBy_xrpusd_CurrencyPair()
        {
            // Act
            _orderList = _library.GetOrderListByCurrencyPair(CurrencyPairs.xrpusd).Result;

            // Assert
            CheckResult(_orderList);
        }

        /// <summary>
        /// Help method to check results
        /// </summary>
        private void CheckResult(OrderList orderList)
        {
            Assert.IsNotNull(orderList);
            Assert.IsTrue(orderList.Asks.Count > 0);
            Assert.IsTrue(orderList.Bids.Count > 0);
            Assert.IsNotNull(orderList.Timestamp);
            Assert.IsNull(orderList.Error);
            Assert.IsNull(orderList.Reason);
            Assert.IsNull(orderList.Status);
        }
    }
}