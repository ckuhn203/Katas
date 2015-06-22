using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class CashierTests
    { 
        [TestMethod]
        public void Cashier_WhenNoProducts_PriceIsZero()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>();

            var price = cashier.Checkout(products);

            Assert.AreEqual(0, price);
        }

        [TestMethod]
        public void Cashier_OneA_Is50()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() { new Sku('A') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(50, price);
        }

        [TestMethod]
        public void Cashier_TwoA_Is100()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('A'), 2));

            var price = cashier.Checkout(products);

            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void Cashier_ThreeA_Is130()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('A'), 3));

            var price = cashier.Checkout(products);

            Assert.AreEqual(130, price);
        }

        [TestMethod]
        public void Cashier_FourA_Is180()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('A'), 4));

            var price = cashier.Checkout(products);

            Assert.AreEqual(180, price);
        }

        [TestMethod]
        public void Cashier_SixA_Is260()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('A'), 6));

            var price = cashier.Checkout(products);

            Assert.AreEqual(260, price);
        }

        [TestMethod]
        public void Cashier_OneB_Is30()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() { new Sku('B') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }

        [TestMethod]
        public void Cashier_TwoBIs45()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('B'), 2));

            var price = cashier.Checkout(products);

            Assert.AreEqual(45, price);
        }

        [TestMethod]
        public void Cashier_ThreeBIs75()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('B'), 3));

            var price = cashier.Checkout(products);

            Assert.AreEqual(75, price);
        }

        public void Cashier_FourBIs90()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('B'), 4));

            var price = cashier.Checkout(products);

            Assert.AreEqual(90, price);
        }

        [TestMethod]
        public void Cashier_OneAOneB_Is80()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() {new Sku('A'), new Sku('B') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(80, price);
        }

        [TestMethod]
        public void Cashier_OneATwoB_OutOfOrder_Is95()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() { new Sku('B'), new Sku('A'), new Sku('B') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(95, price);
        }

        [TestMethod]
        public void Cashier_OneC_Is20()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() { new Sku('C') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(20, price);
        }

        [TestMethod]
        public void Cashier_TwoC_Is20()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('C'), 2));

            var price = cashier.Checkout(products);

            Assert.AreEqual(40, price);
        }

        [TestMethod]
        public void Cashier_OneD_Is15()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>() {new Sku('D') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(15, price);
        }

        [TestMethod]
        public void Cashier_TwoD_Is30()
        {
            var cashier = new Cashier(GetSkuPricingStrategies());
            var products = new List<Sku>(Enumerable.Repeat(new Sku('D'), 2));

            var price = cashier.Checkout(products);

            Assert.AreEqual(30, price);
        }

        [TestMethod]
        public void Cashier_PercentOffStrategy()
        {
            var strategies = GetSkuPricingStrategies();

            var cashier = new Cashier(strategies);
            var products = new List<Sku>() {new Sku('E') };

            var price = cashier.Checkout(products);

            Assert.AreEqual(90, price);
        }

        [TestMethod]
        public void Cashier_PercentOffStrategy_MultipleItems()
        {
            var strategies = GetSkuPricingStrategies();

            var cashier = new Cashier(strategies);
            var products = new List<Sku>(Enumerable.Repeat(new Sku('F'), 2));

            var price = cashier.Checkout(products);

            Assert.AreEqual(4.50m, price);
        }

        private static Dictionary<Sku, IPricingStrategy> GetSkuPricingStrategies()
        {
            return new Dictionary<Sku, IPricingStrategy>()
            {
                { new Sku('A'), new XForYStrategy(50, 130, 3) },
                { new Sku('B'), new XForYStrategy(30, 45, 2) },
                { new Sku('C'), new RegularStrategy(20) },
                { new Sku('D'), new RegularStrategy(15) },
                { new Sku('E'), new PercentOffStrategy(100, 10) },
                { new Sku('F'), new PercentOffStrategy(2.50m, 10) }
            };
        }
    }
}
