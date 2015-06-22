﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class SkuTests
    {
        [TestMethod]
        public void Sku_ImplicitCastFromSkuToSku()
        {
            var original = new Sku('A');
            var expected = new Sku('B');

            original = expected;

            Assert.AreEqual(expected, original);
            Assert.AreNotSame(expected, original);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromSkuToChar()
        {
            var sku = new Sku('A');

            Assert.AreEqual('A', (char)sku);
        }

        [TestMethod]
        public void Sku_ExplicitCastFromCharToSku()
        {
            var sku = new Sku('A');

            Assert.AreEqual(sku, (Sku)'A');
        }

        [TestMethod]
        public void Sku_CharAndSkuHaveSameHashCode()
        {
            var sku = new Sku('A');
            var chr = 'A';

            Assert.AreEqual(chr.GetHashCode(), sku.GetHashCode());
        }

        [TestMethod]
        public void Sku_SkuAndSkuHaveSameHashCode()
        {
            var sku1 = new Sku('A');
            var sku2 = new Sku('A');

            Assert.AreEqual(sku1.GetHashCode(), sku2.GetHashCode());
        }

        [TestMethod]
        public void Sku_CanCreateNewSkuFromExisting()
        {
            var sku1 = new Sku('A');
            var sku2 = sku1;

            Assert.AreEqual(sku1, sku2);
            Assert.AreNotSame(sku1, sku2);
        }

        [TestMethod]
        public void Sku_CanUseEqualsOperator()
        {
            Sku sku1 = new Sku('A');
            Sku sku2 = new Sku('A');

            Assert.IsTrue(sku1 == sku2);
        }

        [TestMethod]
        public void Sku_TwoDifferentSkusAreUnEqual()
        {
            Sku sku1 = new Sku('A');
            Sku sku2 = new Sku('B');

            Assert.AreNotEqual(sku1, sku2);
        }

        [TestMethod]
        public void Sku_ToStringIsAsExpected()
        {
            var sku = new Sku('A');
            Assert.AreEqual("A", sku.ToString());
        }
    }
}
