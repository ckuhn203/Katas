using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class SkuTests
    {
        [TestMethod]
        public void ImplicitCastFromCharToSku()
        {
            var sku = new Sku('A');
            sku = 'B';

            Assert.AreEqual('B', sku);
        }

        [TestMethod]
        public void ImplicitCastFromSkuToSku()
        {
            var original = new Sku('A');
            var expected = new Sku('B');

            original = expected;

            Assert.AreEqual(expected, original);
        }

        [TestMethod]
        public void ExplicitCastFromSkuToChar()
        {
            var sku = new Sku('A');

            Assert.AreEqual('A', (char)sku);
        }

        [TestMethod]
        public void ExplicitCastFromCharToSku()
        {
            var sku = new Sku('A');

            Assert.AreEqual(sku, (Sku)'A');
        }

        [TestMethod]
        public void CharAndSkuHaveSameHashCode()
        {
            var sku = new Sku('A');
            var chr = 'A';

            Assert.AreEqual(chr.GetHashCode(), sku.GetHashCode());
        }

        [TestMethod]
        public void SkuAndSkuHaveSameHashCode()
        {
            var sku1 = new Sku('A');
            var sku2 = new Sku('A');

            Assert.AreEqual(sku1.GetHashCode(), sku2.GetHashCode());
        }

        [TestMethod]
        public void CanCreateNewSkuFromExisting()
        {
            var sku1 = new Sku('A');
            var sku2 = new Sku(sku1);

            Assert.AreEqual(sku1, sku2);
        }

        [TestMethod]
        public void CanUseEqualsOperator()
        {
            Sku sku1 = 'A';
            Sku sku2 = 'A';

            Assert.IsTrue(sku1 == sku2);
        }

        [TestMethod]
        public void TwoDifferentSkusAreUnEqual()
        {
            Sku sku1 = 'A';
            Sku sku2 = 'B';

            Assert.AreNotEqual(sku1, sku2);
        }
    }
}
