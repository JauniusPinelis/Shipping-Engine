using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.Discounts;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDiscountFactory
	{
		IDiscount Build(Shipment order);
	}
}