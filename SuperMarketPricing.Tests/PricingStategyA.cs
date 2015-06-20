using System;

namespace SuperMarketPricing.Tests
{
    internal class PricingStategyA : IPricingStrategy
    {
        public Sku Sku { get; } = 'A';

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= 3)
            {
                result = result + 130;
                count = count - 3;
            }

            return result + (50 * count);
        }
    }
}