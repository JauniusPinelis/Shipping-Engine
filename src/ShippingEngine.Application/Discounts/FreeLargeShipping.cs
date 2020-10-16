﻿
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Discounts
{
	public class FreeLargeShipping : IDiscount
	{
		private readonly IDataService _dataService;

		public FreeLargeShipping(IDataService dataService)
		{
			_dataService = dataService;
		}

		public void ApplyDiscount(Shipment order)
		{
			if (order.Size == "L")
			{
				var customerINfo = _dataService.GetDiscountInfo();

				int orderCount;

				bool outcome = customerINfo.LargeShipmentsTrack.TryGetValue(order.Date, out orderCount);

				if (outcome)
				{
					order.Discount = order.Price;
					order.Price = 0;
				}
			}
		}
	}
}
