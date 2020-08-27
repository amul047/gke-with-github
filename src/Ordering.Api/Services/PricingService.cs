using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Api.Services.Interfaces;
using Ordering.Api.Services.Settings;
using RestSharp;

namespace Ordering.Api.Services
{
    public class PricingService : IPricingService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly ILogger<PricingService> _pricingServiceLogger;
        private readonly Random _random = new Random();
        private readonly SupplierApiSettings _supplierApiSettings;

        public PricingService(
            IHostEnvironment hostEnvironment,
            IOptions<SupplierApiSettings> supplierApiSettingsOptions,
            ILogger<PricingService> pricingServiceLogger)
        {
            _hostEnvironment = hostEnvironment;
            _pricingServiceLogger = pricingServiceLogger;
            _supplierApiSettings = supplierApiSettingsOptions.Value;
        }

        public decimal GetPricing(string orderItem)
        {
            _pricingServiceLogger.LogInformation($"Pricing service is trying to get price for {orderItem}");

            if (_hostEnvironment.IsEnvironment("localhost"))
            {
                _pricingServiceLogger.LogInformation($"Pricing service is pretending to get price for {orderItem}");
                return _random.Next(1, 1000);
            }

            _pricingServiceLogger.LogInformation($"Pricing service is calling supplier API at {_supplierApiSettings.Url} to get price for {orderItem}");
            try
            {
                var restClient = new RestClient(_supplierApiSettings.Url);
                var response = restClient.Get<decimal>(new RestRequest($"/prices?supplierItem={orderItem}"));
                _pricingServiceLogger.LogInformation($"Supplier API responded with status code {response.StatusCode}");

                _pricingServiceLogger.LogInformation($"Supplier cost for {orderItem} is {response.Data}");
                return response.Data;
            }
            catch (Exception exception)
            {
                _pricingServiceLogger.LogError(exception, "An exception occurred calling Supplier API");
                throw;
            }
        }
    }
}