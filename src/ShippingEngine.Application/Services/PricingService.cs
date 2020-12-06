using ShippingEngine.Domain.Interfaces;
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

		public (decimal?, decimal?) CalculatePriceDiscount(Shipment shipment)
		{
			decimal? price = shipment.Price;
			decimal? discount = 0.0M;

			var discountStrategy = _discountFactory.Build(shipment);
			if (discountStrategy != null)
			{
				(price, discount) = discountStrategy.CalculatePriceDiscount(shipment);
			}

			return (price, discount);
		}

		public decimal CalculatePrice(Shipment shipment)
		{
			return _dataService.GetPrice(shipment.Provider, shipment.Size);
		}

	}
}
