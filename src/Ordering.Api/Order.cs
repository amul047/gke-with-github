using System.Collections.Generic;

namespace Ordering.Api
{
    public class Order
    {
        public string Supplier { get; set; }

        public List<string> OrderItems { get; set; }

        public decimal Total { get; set; }
    }
}