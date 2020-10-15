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
	public class PricingStrategyFactory : IPricingStrategyFactory
	{
		private const int DISCOUNT_LIMIT = 10;
		private const int FREE_LARGE_SHIPPING_COUNTER = 3;

		private readonly IDataService _dataService;



		public PricingStrategyFactory(IDataService dataService)
		{
			_dataService = dataService;
		}

		public IPricingStrategy Build(Order order)
		{
			var pricings = _dataService.GetPricings();
			var discountInfo = _dataService.GetDiscountInfo();

			var consumedDiscounts = discountInfo.AccumulatedDiscountsAMonth
				.Where(k => k.Item1 == order.Date).Select(k => k.Item2).Sum();

			var usedLargeShippments = discountInfo.LargeShipmentsAmonth.FirstOrDefault(l => l.Key == order.Date).Value;

			if (order.Size == "S" && consumedDiscounts < DISCOUNT_LIMIT)
			{
				return new LowestPriceStrategy();
			}
			else if (order.Size == "S")
			{
				//RegularPricingStrategy
				return new LowestPriceStrategy();
			}
			else if (order.Size == "L" && usedLargeShippments == FREE_LARGE_SHIPPING_COUNTER)
			{
				return new LowestPriceStrategy();
			}
			else
			{
				return new LowestPriceStrategy();
			}
		}
	}
}
