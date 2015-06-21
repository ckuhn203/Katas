using System;

namespace SuperMarketPricing
{
    public class BogoStrategy : IPricingStrategy
    {
        private double _price;

        public BogoStrategy(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "Cannot be less than zero.");
            }

            _price = price;
        }

        public double GetPrice(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, "Cannot be less than zero.");
            }

            double result = 0;
            
            while (count - 2 > 0)
            {
                result = result + _price;
                count = count - 2;
            }

            if (count > 0)
            {
                result = result + _price;
            }

            return result;
        }
    }
}
