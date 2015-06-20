using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing
{
    public class Cashier
    {
        private List<IPricingStrategy> _pricingStrategies;

        public Cashier(List<IPricingStrategy> pricingStrategies)
        {
            _pricingStrategies = pricingStrategies;
        }

        public double Checkout(IList<Sku> products)
        {
            double result = 0;
            foreach(var strat in _pricingStrategies)
            {
                var prods = products.Where(p => p == strat.Sku);
                result = result + strat.GetPrice(prods.Count());
            }

            return result;
        }
    }
}
