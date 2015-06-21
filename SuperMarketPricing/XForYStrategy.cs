﻿namespace SuperMarketPricing
{
    /// <summary>
    /// Uses a "10 for $10" type pricing strategy. 
    /// The shopper must purchase <paramref name="x"/> to get the discount.
    /// </summary>
    public class XForYStrategy : IPricingStrategy
    {
        private double _pricePerOne;
        private double _pricePerX;
        private int _x;

        public Sku Sku { get; }

        /// <param name="sku">The <see cref="Sku"/> to use this strategy.</param>
        /// <param name="price">The regular every day price.</param>
        /// <param name="pricePerX">Price per every <paramref name="x"/> items purchased.</param>
        /// <param name="x">The number of items that must be purchased to get the discount.</param>
        public XForYStrategy(Sku sku, double price, double pricePerX, int x)
        {
            Sku = sku;
            _pricePerOne = price;
            _pricePerX = pricePerX;
            _x = x;
        }

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= _x)
            {
                result = result + _pricePerX;
                count = count - _x;
            }

            return result + (_pricePerOne * count);   
        }
    }
}