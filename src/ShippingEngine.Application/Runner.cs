using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingEngine.Application
{
	public class Runner
	{
		private readonly IPricingService _discountService;

		public Runner(IPricingService discountService)
		{
			_discountService = discountService;
		}

		public void Run()
		{
			_discountService.ImportData();
			_discountService.CalculateDiscounts();
		}
	}
}
