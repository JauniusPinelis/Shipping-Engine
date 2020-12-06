﻿using ShippingEngine.Application.Services;
using ShippingEngine.Domain.Interfaces;

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
