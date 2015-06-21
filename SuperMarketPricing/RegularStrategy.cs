namespace SuperMarketPricing
{
    public class RegularStrategy : IPricingStrategy
    {
        public Sku Sku { get; }
        protected double Price { get; }

        public RegularStrategy(Sku sku, double price)
        {
            Sku = sku;
            Price = price;
        }

        public double GetPrice(int count)
        {
            return Price * count;
        }
    }
}
