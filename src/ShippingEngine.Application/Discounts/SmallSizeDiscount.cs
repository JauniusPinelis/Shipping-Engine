using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Discounts;
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
			var smallestPrice = _dataService.GetPricings()
				.Where(p => p.Size == order.Size).OrderBy(p => p.Size).First().Price;

			return (smallestPrice, order.Price - smallestPrice);
		}
	}
}
