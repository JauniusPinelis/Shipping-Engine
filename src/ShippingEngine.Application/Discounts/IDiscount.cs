using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Discounts
{
	public interface IDiscount
	{
		Discount ApplyDiscount();
	}
}