using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Domain.Models
{
    public class Discount
    {
        public decimal Price { get; set; }

        public decimal Saved { get; set; }
    }
}
