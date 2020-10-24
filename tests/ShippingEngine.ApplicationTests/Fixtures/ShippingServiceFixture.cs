using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;

namespace ShippingEngine.ApplicationTests.Fixtures
{
	public class ShippingServiceFixture
	{
		public readonly IShippingService ShippingService;
		public readonly IDataService DataService;

		public ShippingServiceFixture()
		{
			var _fileService = new FileService();

			DataService = new DataService(_fileService);

			var discountFactory = new DiscountFactory(DataService);

			var _pricingService = new PricingService(DataService, discountFactory);

			ShippingService = new ShippingService(DataService, _pricingService);
		}
	}
}
