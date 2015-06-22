namespace SuperMarketPricing
{
    /// <summary>
    /// Uses a "10 for $10" type pricing strategy. 
    /// The shopper must purchase <paramref name="x"/> to get the discount.
    /// </summary>
    public class XForYStrategy : IPricingStrategy
    {
        private decimal _pricePerOne;
        private decimal _pricePerX;
        private int _x;
        
        /// <param name="price">The regular every day price.</param>
        /// <param name="pricePerX">Price per every <paramref name="x"/> items purchased.</param>
        /// <param name="x">The number of items that must be purchased to get the discount.</param>
        public XForYStrategy(decimal price, decimal pricePerX, int x)
        {
            _pricePerOne = price;
            _pricePerX = pricePerX;
            _x = x;
        }

        public decimal GetPrice(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            decimal result = 0;

            while (count >= _x)
            {
                result = result + _pricePerX;
                count = count - _x;
            }

            return result + (_pricePerOne * count);   
        }
    }
}