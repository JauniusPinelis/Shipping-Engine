using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.ApplicationTests.Fixtures
{
    public class ShippingServiceFixture
    {
		public readonly ShippingService PricingService;
		public readonly DataService DataService;

		public ShippingServiceFixture()
		{
			var _fileService = new FileService();
			DataService = new DataService(_fileService);

			var discountFactory = new DiscountFactory(DataService);

			PricingService = new ShippingService(DataService, discountFactory);
		}
	}
}
