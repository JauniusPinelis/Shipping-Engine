using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Discounts
{
	public class SmallSizeDiscount : IDiscount
	{
		private readonly IDataService _dataService;

		public SmallSizeDiscount(IDataService dataService)
		{
			_dataService = dataService;
		}

		public void ApplyDiscount(Shipment order)
		{
			var smallestPrice = _dataService.GetPricings()
				.Where(p => p.Size == order.Size).OrderBy(p => p.Size).First().Price;

			order.Discount = order.Price - smallestPrice;
			order.Price = smallestPrice;

			_dataService.SaveDiscountInfo(order.Date, order.Discount.Value);
		}
	}
}
