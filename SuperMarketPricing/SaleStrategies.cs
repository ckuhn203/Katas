namespace SuperMarketPricing
{
    public abstract class SaleStrategy : IPricingStrategy
    {
        public abstract Sku Sku { get; }
        protected abstract double PricePerOne { get; }
        protected abstract double PricePerX { get; }
        protected abstract int X { get; }

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= X)
            {
                result = result + PricePerX;
                count = count - X;
            }

            return result + (PricePerOne * count);   
        }
    }

    public class PricingStategyA : SaleStrategy
    {
        public override Sku Sku { get; } = 'A';
        protected override double PricePerOne { get; } = 50;
        protected override double PricePerX { get; } = 130;
        protected override int X { get; } = 3;
    }

    public class PricingStrategyB : SaleStrategy
    {
        public override Sku Sku { get; } = 'B';
        protected override double PricePerOne { get; } = 30;
        protected override double PricePerX { get; } = 45;
        protected override int X { get; } = 2;
    }
}