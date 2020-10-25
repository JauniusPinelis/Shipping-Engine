using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Helpers;
using ShippingEngine.Domain.Models;
using System.Linq;

namespace ShippingEngine.Application.Services
{
	public class ShippingService : IShippingService
	{
		private readonly IDataService _dataService;
		private readonly IPricingService _pricingService;

		public ShippingService(IDataService dataService, IPricingService pricingService)
		{
			_dataService = dataService;
			_pricingService = pricingService;
		}

		public void ProcessShipments()
		{
			var orders = _dataService.GetShipments().ToList();

			foreach (var order in orders.Where(o => o.Valid))
				ProcessShipment(order);

			_dataService.OverwriteShipments(orders);
		}

		public void ImportData()
		{
			_dataService.ImportShipments();
			_dataService.ImportPricings();
		}

		private void ProcessShipment(Shipment shipment)
		{

			shipment.Price = _pricingService.CalculatePrice(shipment);

			(decimal? price, decimal? discount) = _pricingService.CalculatePriceDiscount(shipment);

			if (discount.HasValue)
			{
				shipment.Price = price;
				shipment.Discount = discount;

				_dataService.IncrementAccumulatedDiscounts(shipment.Date.RemoveDays(), shipment.Discount.Value);
			}

			else
			{
				shipment.Discount = 0;
			}
		}
	}
}
