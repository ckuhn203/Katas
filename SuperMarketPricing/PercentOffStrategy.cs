namespace SuperMarketPricing
{
    public class PercentOffStrategy : IPricingStrategy
    {
        private int _percentOff;
        private double _price;

        public Sku Sku { get; }

        public PercentOffStrategy(Sku sku, double price, int percentOff)
        {
            Sku = sku;
            _price = price;
            _percentOff = percentOff;
        }

        public double GetPrice(int count)
        {
            return (_price - (_price / _percentOff)) * count;
        }
    }
}
