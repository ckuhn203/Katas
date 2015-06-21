using System;

namespace SuperMarketPricing
{
    /// <summary>
    /// Buy One Get One pricing strategy.
    /// </summary>
    public class BogoStrategy : BuyXGetOneStrategy
    {
        /// <param name="price">Regular every day price.</param>
        public BogoStrategy(double price)
            : base(price, 2)
        { }
    }

    /// <summary>
    /// Buy X Get One pricing strategy.
    /// </summary>
    public class BuyXGetOneStrategy : IPricingStrategy
    {
        private double _price;
        private int _xToBuy;

        /// <param name="price">Regular everyday price.</param>
        /// <param name="xToBuy">Number of items that must be purchased to get the discount.</param>
        public BuyXGetOneStrategy(double price, int xToBuy)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "Cannot be less than zero.");
            }

            if (xToBuy < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(xToBuy), xToBuy, "Cannot be less than two.");
            }

            _price = price;
            _xToBuy = xToBuy;
        }

        public double GetPrice(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot be less than zero.");
            }

            double result = 0;

            while (count - _xToBuy > 0)
            {
                result = result + _price;
                count = count - _xToBuy;
            }

            if (count > 0)
            {
                result = result + _price;
            }

            return result;
        }
    }
}
