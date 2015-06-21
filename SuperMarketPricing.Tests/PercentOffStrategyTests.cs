using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class PercentOffStrategyTests
    {
        [TestMethod]
        public void PercentOff_SingleItem()
        {
            var strat = new PercentOffStrategy(100, 10);

            var price = strat.GetPrice(1);

            Assert.AreEqual(90, price);
        }

        [TestMethod]
        public void PercentOff_MultipleItems()
        {
            var strat = new PercentOffStrategy(2.50, 10);

            var price = strat.GetPrice(2);

            Assert.AreEqual(4.50, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PercentOff_WhenPercentageIsEqualToZero_ThrowsArgOutOfRangeException()
        {
            var strat = new PercentOffStrategy(100, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PercentOff_WhenPercentageIsLessThanZero_ThrowsArgOutOfRangeException()
        {
            var strat = new PercentOffStrategy(100, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PercentOff_WhenPercentageIsGreaterThanEqualToOneHundred_ThrowsOutOfRangeException()
        {
            var strat = new PercentOffStrategy(100, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PercentOff_WhenPriceIsNegative_ThrowsOutOfRangeException()
        {
            var strat = new PercentOffStrategy(-20, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PercentOff_GetPrice_WhenCountIsNegative_ThrowsOutOfRangeException()
        {
            var strat = new PercentOffStrategy(100, 10);

            var price = strat.GetPrice(-5);
        }

    }
}
