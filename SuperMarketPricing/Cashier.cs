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
            var aProducts = products.Where(p => p == 'A');
            var strategy = pricingStrategies.Where(s => s.Sku == 'A').First();

            return strategy.GetPrice(aProducts.Count());
        }
    }
}
