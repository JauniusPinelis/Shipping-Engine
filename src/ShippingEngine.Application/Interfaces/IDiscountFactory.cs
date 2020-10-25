using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDiscountFactory
	{
		IDiscount Build(Shipment shipment);
	}
}