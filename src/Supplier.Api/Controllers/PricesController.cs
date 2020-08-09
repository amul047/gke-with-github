﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Supplier.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly ILogger<PricesController> _logger;

        public PricesController(ILogger<PricesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public decimal Get([FromQuery] string supplierItem)
        {
            _logger.LogInformation($"GET /Prices requested for {supplierItem}");
            var rng = new Random();
            return rng.Next(1, 1000);
        }
    }
}