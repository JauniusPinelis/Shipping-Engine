using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Services
{
    public class PricingService : IPricingService
    {
		private readonly IDataService _dataService;
		private readonly IDiscountFactory _discountFactory;

		public PricingService( IDataService dataService, 
			IDiscountFactory discountFactory)
		{
			_dataService = dataService;
			_discountFactory = discountFactory;
		}

		public void CalculateDiscounts()
		{
			var orders = _dataService.GetOrders().ToList();

			orders.ForEach(o => SetPrice(o));

		}

		public void ImportData()
		{
			_dataService.ImportOrders();
			_dataService.ImportPricings();
		}

		private void SetPrice(Order order)
		{
			order.Price = _dataService.GetPrice(order.Provider, order.Size);
			ApplyDiscount(order);
		}

		private void ApplyDiscount(Order order)
		{
			var discount = _discountFactory.Build(order);
			if (discount != null)
			{
				order.Apply(discount);
			}
		}
    }
}
