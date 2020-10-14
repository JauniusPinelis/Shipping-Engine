using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.PricingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Factories
{
    public class PricingStrategyFactory
    {
		private readonly IDataService _dataService;

		public PricingStrategyFactory(IDataService dataService)
		{
			_dataService = dataService;
		}

        public IPricingStrategy Build(Order order)
		{
			var pricings = _dataService.GetPricings();
			var discountInfo = _dataService.GetDiscountInfo();

			return new LowestPriceStrategy();
		}
    }
}
