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
            var aStrat = pricingStrategies.Where(s => s.Sku == 'A').First();
            var aProducts = products.Where(p => p == aStrat.Sku);

            var bStrat = pricingStrategies.Where(s => s.Sku == 'B').First();
            var bProducts = products.Where(p => p == bStrat.Sku);

            return aStrat.GetPrice(aProducts.Count()) + bStrat.GetPrice(bProducts.Count());
        }
    }
}
