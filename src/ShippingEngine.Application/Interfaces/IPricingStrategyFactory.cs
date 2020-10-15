using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.PricingStrategies;

namespace ShippingEngine.Application.Interfaces
{
	public interface IPricingStrategyFactory
	{
		IPricingStrategy Build(Order order);
	}
}