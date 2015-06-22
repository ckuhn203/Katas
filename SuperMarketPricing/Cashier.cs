using System.Collections.Generic;
using System.Linq;

namespace SuperMarketPricing
{
    public class Cashier
    {
        private Dictionary<Sku, IPricingStrategy> _pricingStrategies;

        public Cashier(Dictionary<Sku, IPricingStrategy> pricingStrategies)
        {
            _pricingStrategies = pricingStrategies;
        }

        public decimal Checkout(IList<Sku> products)
        {
            decimal result = 0;
            foreach(var strat in _pricingStrategies)
            {
                var prods = products.Where(p => p == strat.Key);
                result = result + strat.Value.GetPrice(prods.Count());
            }

            return result;
        }
    }
}
