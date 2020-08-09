using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ordering.Api.Services.Interfaces;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IPricingService _pricingService;

        public OrdersController(ILogger<OrdersController> logger, IPricingService pricingService)
        {
            _logger = logger;
            _pricingService = pricingService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            _logger.LogInformation("GET /Orders requested");
            var orderItems = new List<string>
            {
                "cycle",
                "shirt",
                "pen"
            };
            var total = orderItems.Select(orderItem => _pricingService.GetPricing(orderItem))
                .Sum();
            return new List<Order>
            {
                new Order
                {
                    Supplier = "KMart",
                    OrderItems = orderItems,
                    Total = total
                }
            };
        }
    }
}