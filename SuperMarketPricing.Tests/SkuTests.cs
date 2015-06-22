using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class SkuTests
    {
        [TestMethod]
        public void Sku_ImplicitCastFromSkuToSku()
        {
            var original = new Sku(1);
            var expected = new Sku(2);

            original = expected;

            Assert.AreEqual(expected, original);
            Assert.AreNotSame(expected, original);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromSkuToChar()
        {
            var sku = new Sku(1);

            Assert.AreEqual(1, (int)sku);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromCharToSku()
        {
            var sku = new Sku(1);

            Assert.AreEqual(sku, (Sku)1);
        }

        [TestMethod]
        public void Sku_IntAndSkuHaveSameHashCode()
        {
            var sku = new Sku(1);
            var i = 1;

            Assert.AreEqual(i.GetHashCode(), sku.GetHashCode());
        }

        [TestMethod]
        public void Sku_SkuAndSkuHaveSameHashCode()
        {
            var sku1 = new Sku(1);
            var sku2 = new Sku(1);

            Assert.AreEqual(sku1.GetHashCode(), sku2.GetHashCode());
        }

        [TestMethod]
        public void Sku_CanCreateNewSkuFromExisting()
        {
            var sku1 = new Sku(1);
            var sku2 = sku1;

            Assert.AreEqual(sku1, sku2);
            Assert.AreNotSame(sku1, sku2);
        }

        [TestMethod]
        public void Sku_CanUseEqualsOperator()
        {
            Sku sku1 = new Sku(1);
            Sku sku2 = new Sku(1);

            Assert.IsTrue(sku1 == sku2);
        }

        [TestMethod]
        public void Sku_TwoDifferentSkusAreUnEqual()
        {
            Sku sku1 = new Sku(1);
            Sku sku2 = new Sku(2);

            Assert.AreNotEqual(sku1, sku2);
        }

        [TestMethod]
        public void Sku_ToStringIsAsExpected()
        {
            var sku = new Sku(1);
            Assert.AreEqual("0000000001", sku.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sku_GreaterThanMax_ThrowsArgumentOutOfRangeException()
        {
            var sku = new Sku(Sku.MaxValue + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sku_LessThanMin_ThrowsArgumentOutOfRangeException()
        {
            var sku = new Sku(Sku.MinValue - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Sku_NegativeCastToSku_ThrowsInvalidCastException()
        {
            var num = -1;
            var foo = (Sku)num;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Sku_BiggerThanMaxToSku_ThrowsInvalidCastException()
        {
            var num = Sku.MaxValue + 1;
            var foo = (Sku)num;
        }
    }
}
