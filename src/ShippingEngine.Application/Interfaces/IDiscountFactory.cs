using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.PricingStrategies;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDiscountFactory
	{
		IDiscount Build(Order order);
	}
}