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

		public DiscountService(IFileService fileService, IDataService dataService)
		{
			_fileService = fileService;
			_dataService = dataService;
		}

		public void CalculateDiscounts()
		{
			var orders = _dataService.GetOrders().ToList();
			var pricings = _dataService.GetPricings().ToList();

			orders.ForEach(o => SetDiscount(o));

		}

		public void ImportData()
		{
			_dataService.ImportOrders();
			_dataService.ImportPricings();
		}

		private void SetDiscount(Order order)
		{
			
		}
    }
}
