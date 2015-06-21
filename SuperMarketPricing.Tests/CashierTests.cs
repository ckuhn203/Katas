using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class CashierTests
    { 
        [TestMethod]
        public void Cashier_WhenNoProducts_PriceIsZero()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>();

            var price = cashier.Checkout(products);

            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void Cashier_OneA_Is50()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(50, price);
        }

        [TestMethod]
        public void Cashier_TwoA_Is100()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void Cashier_ThreeA_Is130()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(130, price);
        }

        [TestMethod]
        public void Cashier_FourA_Is180()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(180, price);
        }

        [TestMethod]
        public void Cashier_SixA_Is260()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'A', 'A', 'A', 'A', 'A' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(260, price);
        }

        [TestMethod]
        public void Cashier_OneB_Is30()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }

        [TestMethod]
        public void Cashier_TwoBIs45()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(45, price);
        }

        [TestMethod]
        public void Cashier_ThreeBIs75()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(75, price);
        }

        public void Cashier_FourBIs90()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'B', 'B', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(90, price);
        }

        [TestMethod]
        public void Cashier_OneAOneB_Is80()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'A', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(80, price);
        }

        [TestMethod]
        public void Cashier_OneATwoB_OutOfOrder_Is95()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'B', 'A', 'B' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(95, price);
        }

        [TestMethod]
        public void Cashier_OneC_Is20()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'C' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(20, price);
        }

        [TestMethod]
        public void Cashier_TwoC_Is20()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'C', 'C' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(40, price);
        }

        [TestMethod]
        public void Cashier_OneD_Is15()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'D' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(15, price);
        }

        [TestMethod]
        public void Cashier_TwoD_Is30()
        {
            var cashier = new Cashier(GetPricingStrategies());
            var products = new List<Sku>() { 'D', 'D' };

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }

        private static List<IPricingStrategy> GetPricingStrategies()
        {
            return new List<IPricingStrategy>()
            {
                new XForYStrategy('A', 50, 130, 3),
                new XForYStrategy('B', 30, 45, 2),
                new RegularStrategy('C',20),
                new RegularStrategy('D',15)
            };
        }
    }
}
