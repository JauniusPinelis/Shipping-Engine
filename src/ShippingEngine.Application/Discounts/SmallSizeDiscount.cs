using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Enums;
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

		public (decimal?, decimal?) CalculatePriceDiscount(Shipment shipment)
		{
			if (shipment.Size == Sizes.S)
			{

				var customerInfo = _dataService.GetDiscountInfo();

				var accumulatedDiscounts = customerInfo.AccumulatedDiscountsAMonth
					.Where(a => a.Item1 == shipment.Date.RemoveDays()).Select(a => a.Item2).Sum();

				var remainingDiscount = 10 - accumulatedDiscounts;

				var smallestPrice = _dataService.GetPricings()
					.Where(p => p.Size == shipment.Size).OrderBy(p => p.Size).First().Price;

				var discount = shipment.Price.Value - smallestPrice;

				if (discount > remainingDiscount)
				{
					smallestPrice = smallestPrice + (discount - remainingDiscount);
					discount = remainingDiscount;
				}

				return (smallestPrice, discount);
			}

			else
			{
				return (shipment.Price, shipment.Discount);
			}
		}
	}
}
