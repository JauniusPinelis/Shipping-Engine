using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Services
{
	public class PricingService : IPricingService
	{
		private readonly IDataService _dataService;
		private readonly IDiscountFactory _discountFactory;

		public PricingService(IDataService dataService, IDiscountFactory discountFactory)
		{
			_dataService = dataService;
			_discountFactory = discountFactory;
		}

		public (decimal, decimal) CalculatePriceDiscount(Shipment shipment)
		{
			var price = _dataService.GetPrice(shipment.Provider, shipment.Size);

			ApplyDiscount(shipment);
		}

		private void ApplyDiscount(Shipment shipment)
		{
			var discount = _discountFactory.Build(shipment);
			if (discount != null)
			{
				shipment.Apply(discount);
			}
		}
	}
}
