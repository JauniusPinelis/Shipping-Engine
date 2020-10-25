using ShippingEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Domain.Models
{
    public class Pricing
    {
        public Providers Provider { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
