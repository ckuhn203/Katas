using System;

namespace SuperMarketPricing
{
    public class PricingStategyA : IPricingStrategy
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

    public class PricingStrategyB : IPricingStrategy
    {
        public Sku Sku { get; } = 'B';

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= 2)
            {
                result = result + 45;
                count = count - 2;
            }

            return result + (30 * count);
        }
    }
}