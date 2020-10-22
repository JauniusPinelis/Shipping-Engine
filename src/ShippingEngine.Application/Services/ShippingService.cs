using ShippingEngine.Application.Interfaces;
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

			_dataService.ExportOrders(orders);
		}

		public void ImportData()
		{
			_dataService.ImportOrders();
			_dataService.ImportPricings();
		}

		private void ProcessShipment(Shipment shipment)
		{
			(decimal price, decimal discount) =
				_pricingService.CalculatePriceDiscount(shipment);

			shipment.Price = price;
			shipment.Discount = discount;

			if (shipment.Size == "L")
			{
				_dataService.TrackLargeShipments(shipment.Date);
			}
		}

		public void ExportData()
		{

		}
	}
}
