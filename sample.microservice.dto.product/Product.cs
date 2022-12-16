using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.microservice.dto.product
{
    public class Product
    {
        public Guid Id = Guid.NewGuid();
        public string? ProductCode { get; set; }
    }
}
