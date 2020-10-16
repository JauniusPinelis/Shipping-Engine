using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.ApplicationTests.Fixtures
{
    public class PricingServiceFixture
    {
		public readonly PricingService PricingService;
		public readonly DataService DataService;

		public PricingServiceFixture()
		{
			var _fileService = new FileService();
			DataService = new DataService(_fileService);

			var discountFactory = new DiscountFactory(DataService);

			PricingService = new PricingService(DataService, discountFactory);
		}
	}
}
