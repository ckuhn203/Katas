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

            if (count >= 3)
            {
                return 130 + GetPrice(count - 3);
            }

            return 50 * count;
        }
    }
}