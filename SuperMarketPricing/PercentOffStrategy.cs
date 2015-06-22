using System;

namespace SuperMarketPricing
{
    /// <summary>
    /// Uses a "X% Off" Pricing Strategy.
    /// </summary>
    public class PercentOffStrategy : IPricingStrategy
    {
        private int _percentOff;
        private decimal _price;
        
        /// <param name="price">The regular every day price.</param>
        /// <param name="percentOff">Whole number from 1 to 99.</param>
        public PercentOffStrategy(decimal price, int percentOff)
        {
            if (percentOff <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(percentOff), percentOff, "Cannot be less than or equal to zero.");
            }

            if (percentOff >= 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentOff), percentOff, "Cannot be equal to or greater than 100.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "Cannot be less than zero.");
            }

            _percentOff = percentOff;
            _price = price;
        }

        public decimal GetPrice(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot be less than zero.");
            }

            return (_price - (_price / _percentOff)) * count;
        }
    }
}
