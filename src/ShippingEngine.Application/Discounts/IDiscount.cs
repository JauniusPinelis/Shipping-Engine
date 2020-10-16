using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Discounts
{
	public interface IDiscount
	{
		void ApplyDiscount(Shipment order);
	}
}