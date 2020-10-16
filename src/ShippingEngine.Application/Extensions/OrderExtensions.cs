using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Extensions
{
    public static class OrderExtensions
    {
        public static void Apply(this Shipment order, IDiscount discountStrategy)
		{
            discountStrategy.ApplyDiscount(order);
		}
    }
}
