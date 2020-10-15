using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.PricingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Extensions
{
    public static class OrderExtensions
    {
        public static DiscountInfo Apply(this Order order, IPricingStrategy pricingStrategy)
		{
            return null;
		}
    }
}
