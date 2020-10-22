using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Discounts
{
	public interface IDiscount
	{
		(decimal?, decimal?) CalculatePriceDiscount(Shipment order);
	}
}