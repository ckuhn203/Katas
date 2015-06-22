using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class BogoStrategyTests
    {
        [TestMethod]
        public void Bogo_WhenZeroItems_PriceIsZero()
        {
            var strat = new BogoStrategy(2.50m);
            var price = strat.GetPrice(0);

            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void Bogo_WhenOneItem_PriceIsFull()
        {
            var strat = new BogoStrategy(2.50m);
            var price = strat.GetPrice(1);

            Assert.AreEqual(2.50m, price);
        }

        [TestMethod]
        public void Bogo_WhenTwoItems_PriceIsHalf()
        {
            var strat = new BogoStrategy(2.50m);
            var price = strat.GetPrice(2);

            Assert.AreEqual(2.50m, price);
        }

        [TestMethod]
        public void Bogo_WhenThreeItems_PriceIsHalfPlusFull()
        {
            var strat = new BogoStrategy(2.50m);
            var price = strat.GetPrice(3);

            Assert.AreEqual(5.00m, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bogo_WhenItemCountIsNegative_ThrowsArgumentOutOfRangeException()
        {
            var strat = new BogoStrategy(2.50m);
            var price = strat.GetPrice(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Bogo_WhenPriceIsNegative_ThrowsArgumentOutOfRangeException()
        {
            var strat = new BogoStrategy(-2.50m);
        }
    }
}
