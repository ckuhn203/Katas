namespace SuperMarketPricing
{
    public class XForYStrategy : IPricingStrategy
    {
        public Sku Sku { get; }
        protected double PricePerOne { get; }
        protected double PricePerX { get; }
        protected int X { get; }

        public XForYStrategy(Sku sku, double price, double pricePerX, int x)
        {
            Sku = sku;
            PricePerOne = price;
            PricePerX = pricePerX;
            X = x;
        }

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
}