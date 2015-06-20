namespace SuperMarketPricing
{
    public interface IPricingStrategy
    {
        Sku Sku { get; } 
        double GetPrice(int count);
    }
}