using System;

namespace SuperMarketPricing
{
    /// <summary>
    /// Everyday pricing strategy for non-sale items.
    /// </summary>
    public class RegularStrategy : IPricingStrategy
    {
        private double _price;

        public Sku Sku { get; }

        public RegularStrategy(Sku sku, double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "Cannot be less than zero.");
            }

            _price = price;
            Sku = sku;
        }

        public double GetPrice(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot be less than zero.");
            }

            return _price * count;
        }
    }
}
