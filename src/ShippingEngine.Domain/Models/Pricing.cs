using ShippingEngine.Domain.Enums;

namespace ShippingEngine.Domain.Models
{
	public class Pricing
	{
		public Providers Provider { get; set; }
		public Sizes Size { get; set; }
		public decimal Price { get; set; }
	}
}
