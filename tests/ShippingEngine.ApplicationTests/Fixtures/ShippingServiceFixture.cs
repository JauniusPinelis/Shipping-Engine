using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;

namespace ShippingEngine.ApplicationTests.Fixtures
{
	public class ShippingServiceFixture : DiscountFactoryFixture
	{
		public readonly IShippingService ShippingService;

		public ShippingServiceFixture()
		{
			var _pricingService = new PricingService(DataService, DiscountFactory);

			ShippingService = new ShippingService(DataService, _pricingService);
		}
	}
}
