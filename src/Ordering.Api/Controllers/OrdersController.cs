using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ordering.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            _logger.LogInformation("GET /Orders requested");
            return new List<Order>
            {
                new Order
                {
                    Supplier = "KMart",
                    OrderItems = new List<string>
                    {
                        "cycle",
                        "shirt",
                        "pen"
                    },
                    Total = new decimal(259.59)
                }
            };
        }
    }
}