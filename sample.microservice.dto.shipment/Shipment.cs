using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.microservice.dto.shipment
{
    public class Shipment
    {
        public DateTime Date { get; set; }
        public Guid OrderId { get; set; }
        public int NumberOfItems { get; set; }
    }
}
