using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDiscount
	{
		(decimal?, decimal?) CalculatePriceDiscount(Shipment order);
	}
}