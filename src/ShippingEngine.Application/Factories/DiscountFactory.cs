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
	public class DiscountFactory : IDiscountFactory
	{
		private const int DISCOUNT_LIMIT = 10;
		private const int FREE_LARGE_SHIPPING_COUNTER = 3;

		private readonly IDataService _dataService;

		public DiscountFactory(IDataService dataService)
		{
			_dataService = dataService;
		}

		public IDiscount Build(Order order)
		{
			var pricings = _dataService.GetPricings();
			var discountInfo = _dataService.GetDiscountInfo();

			var consumedDiscounts = discountInfo.AccumulatedDiscountsAMonth
				.Where(k => k.Item1 == order.Date).Select(k => k.Item2).Sum();

			var usedLargeShipments = discountInfo.LargeShipmentsAmonth.FirstOrDefault(l => l.Key == order.Date).Value;

			if (order.Size == "S")
			{
				return new SmallSizeDiscount();
			}

			if (order.Size == "L" && usedLargeShipments == FREE_LARGE_SHIPPING_COUNTER)
			{
				return new FreeLargeShippingDiscount();
			}
		}
	}
}
