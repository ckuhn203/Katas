﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricing.Tests
{
    [TestClass]
    public class CashierTests
    {
        private List<IPricingStrategy> _pricingStrategies;
        private Cashier _cashier;

        [TestInitialize]
        public void Initialize()
        {
            _pricingStrategies = GetPricingStrategies();
            _cashier = new Cashier(GetPricingStrategies());
        }

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

        private static List<IPricingStrategy> GetPricingStrategies()
        {
            return new List<IPricingStrategy>() { new PricingStategyA(), new PricingStrategyB() };
        }
    }
}