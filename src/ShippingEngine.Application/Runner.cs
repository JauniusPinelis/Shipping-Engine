using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingEngine.Application
{
	public class Runner
	{
		private readonly IDiscountService _discountService;
		private readonly IFileService _fileService;
		private readonly IDataService _dataService;

		public Runner(IDiscountService discountService, IFileService fileService, DataService dataService)
		{
			_discountService = discountService;
			_fileService = fileService;
			_dataService = dataService;
		}

		public void Run()
		{
			_dataService.ImportOrders();
		}
	}
}
