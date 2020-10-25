using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Helpers;
using ShippingEngine.Domain.Models;
using System.Linq;

namespace ShippingEngine.Application.Discounts
{
	public class SmallSizeDiscount : IDiscount
	{
		private readonly IDataService _dataService;

		public SmallSizeDiscount(IDataService dataService)
		{
			_dataService = dataService;
		}

		public (decimal?, decimal?) CalculatePriceDiscount(Shipment order)
		{
			if (order.Size == "S")
			{

				var customerInfo = _dataService.GetDiscountInfo();

				var accumulatedDiscounts = customerInfo.AccumulatedDiscountsAMonth
					.Where(a => a.Item1 == order.Date.RemoveDays()).Select(a => a.Item2).Sum();

				var remainingDiscount = 10 - accumulatedDiscounts;

				var smallestPrice = _dataService.GetPricings()
					.Where(p => p.Size == order.Size).OrderBy(p => p.Size).First().Price;

				var discount = order.Price.Value - smallestPrice;

				if (discount > remainingDiscount)
				{
					smallestPrice = smallestPrice + (discount - remainingDiscount);
					discount = remainingDiscount;
				}

				return (smallestPrice, discount);
			}

			else
			{
				return (order.Price, order.Discount);
			}
		}
	}
}
