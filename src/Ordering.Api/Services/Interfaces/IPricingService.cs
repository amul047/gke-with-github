namespace Ordering.Api.Services.Interfaces
{
    public interface IPricingService
    {
        public decimal GetPricing(string orderItem);
    }
}