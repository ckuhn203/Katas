namespace SuperMarketPricing
{
    public class XForYStrategy : IPricingStrategy
    {
        private double _pricePerOne;
        private double _pricePerX;
        private int _x;

        public Sku Sku { get; }

        public XForYStrategy(Sku sku, double price, double pricePerX, int x)
        {
            Sku = sku;
            _pricePerOne = price;
            _pricePerX = pricePerX;
            _x = x;
        }

        public double GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            double result = 0;

            while (count >= _x)
            {
                result = result + _pricePerX;
                count = count - _x;
            }

            return result + (_pricePerOne * count);   
        }
    }
}