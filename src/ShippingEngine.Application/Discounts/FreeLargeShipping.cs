
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Helpers;
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

		public (decimal?, decimal?) CalculatePriceDiscount(Shipment order)
		{
			if (order.Size == "L")
			{
				var customerInfo = _dataService.GetDiscountInfo();

				int orderCount;

				bool outcome = customerInfo.LargeShipmentsTrack.TryGetValue(order.Date.RemoveDays(), out orderCount);

				if (outcome && orderCount == 3)
				{
					return (0, order.Price.Value);
				}
			}
			return (order.Price, order.Discount);
		}
	}
}
