using NUnit.Framework;
using UOB.Exchanges.Bitstamp;

namespace bitstampTests
{
    /// <summary>
    /// Class represents a list of tests
    /// </summary>
    public class GetCurrencyPairsTests
    {
        /// <summary>
        /// Represents library class
        /// </summary>
        private Library _library;

        /// <summary>
        /// Represents basic setup
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _library = new Library();
        }

        /// <summary>
        /// Check getting a list of currencies
        /// </summary>
        [Test]
        public void GetCurrencyPairs()
        {
            // Act
            var _tradingPairs = _library.GetCurrencyPairs().Result;

            // Assert
            Assert.IsNotNull(_tradingPairs);
            Assert.IsTrue(_tradingPairs.Count > 0);
            foreach (var item in _tradingPairs)
            {
                Assert.IsNotEmpty(item.Name);
            }
        }
    }
}
