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

		public Runner(IDiscountService discountService, IFileService fileService)
		{
			_discountService = discountService;
			_fileService = fileService;
		}

		public void Run()
		{
			
		}
	}
}
