using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingEngine.Application
{
	public class Runner
	{
		private readonly IPricingService _pricingService;

		public Runner(IPricingService pricingService)
		{
			_pricingService = pricingService;
		}

		public void Run()
		{
			_pricingService.ImportData();
			_pricingService.ProcessShipments();
		}
	}
}
