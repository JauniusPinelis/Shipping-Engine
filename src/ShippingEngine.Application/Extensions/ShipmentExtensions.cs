using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Extensions
{
	public static class ShipmentExtensions
	{
		public static (decimal?, decimal?) Apply(this Shipment shipment, IDiscount discountStrategy)
		{
			return discountStrategy.CalculatePriceDiscount(shipment);
		}
	}
}
