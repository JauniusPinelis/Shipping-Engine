using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Extensions
{
	public static class OrderExtensions
	{
		public static (decimal?, decimal?) Apply(this Shipment order, IDiscount discountStrategy)
		{
			return discountStrategy.CalculatePriceDiscount(order);
		}
	}
}
