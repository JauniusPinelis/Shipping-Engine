using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Models;

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
