using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketPricing
{
    public class Cashier
    {
        private List<IPricingStrategy> pricingStrategies;

        public Cashier(List<IPricingStrategy> pricingStrategies)
        {
            this.pricingStrategies = pricingStrategies;
        }

        public double Checkout(IList<Sku> products)
        {
            double result = 0;
            foreach(var strat in this.pricingStrategies)
            {
                var prods = products.Where(p => p == strat.Sku);
                result = result + strat.GetPrice(prods.Count());
            }

            return result;
        }
    }
}
