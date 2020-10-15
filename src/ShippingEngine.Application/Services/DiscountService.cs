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
    public class DiscountService : IDiscountService
    {
		private readonly IFileService _fileService;
		private readonly IDataService _dataService;
		private readonly IPricingStrategyFactory _pricingStrategyFactory;

		public DiscountService(IFileService fileService, IDataService dataService, 
			IPricingStrategyFactory pricingStrategyFactory)
		{
			_fileService = fileService;
			_dataService = dataService;
			_pricingStrategyFactory = pricingStrategyFactory;
		}

		public void CalculateDiscounts()
		{
			var orders = _dataService.GetOrders().ToList();

			orders.ForEach(o => SetDiscount(o));

		}

		public void ImportData()
		{
			_dataService.ImportOrders();
			_dataService.ImportPricings();
		}

		private void SetDiscount(Order order)
		{
			// First Strategy
			var pricingStrategy = _pricingStrategyFactory.Build(order);

			var updatedOrderInfo = order.Apply(pricingStrategy);

		}
    }
}
