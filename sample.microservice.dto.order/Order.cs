using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.microservice.dto.order
{
    public class Order
    {
        public DateTime Date { get; set; }
        public Guid Id { get; set; }
        public List<OrderItem>? Items { get; set; }
    }

    public class OrderItem
    {
        public string? ProductCode { get; set; }

        public int Quantity { get; set; }
    }
}
