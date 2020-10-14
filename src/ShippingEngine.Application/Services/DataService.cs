using ShippingEngine.Application.Helpers;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Services
{
	public class DataService : IDataService
	{
		public List<Order> Orders = new List<Order>();

		public List<Pricing> Pricings = new List<Pricing>();

		private readonly IFileService _fileService;

		public DataService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public void ImportOrders()
		{
			var orderData = _fileService.ReadOrderData();

			var orders = orderData.Select(o => DataHelpers.ParseOrder(o));

			Orders.AddRange(orders);
		}

		public void ImportPricings()
		{
			var pricingData = _fileService.ReadPricingData();

			var pricings = pricingData.Select(p => DataHelpers.ParsePricing(p));

			Pricings.AddRange(pricings);
		}
	}
}
