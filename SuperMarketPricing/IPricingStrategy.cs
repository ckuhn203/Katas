namespace SuperMarketPricing
{
    public interface IPricingStrategy
    {
        decimal GetPrice(int count);
    }
}