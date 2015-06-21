namespace SuperMarketPricing
{
    public interface IPricingStrategy
    {
        double GetPrice(int count);
    }
}