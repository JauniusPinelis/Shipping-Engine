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
		private List<Order> _orders = new List<Order>();
		private List<Pricing> _pricings = new List<Pricing>();

		private readonly IFileService _fileService;

		public DataService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public void ImportOrders()
		{
			var orderData = _fileService.ReadOrderData();

			var orders = orderData.Select(o => DataHelpers.ParseOrder(o));

			_orders.AddRange(orders);
		}

		public void ImportPricings()
		{
			var pricingData = _fileService.ReadPricingData();

			var pricings = pricingData.Select(p => DataHelpers.ParsePricing(p));

			_pricings.AddRange(pricings);
		}

		public IEnumerable<Pricing> GetPricings()
		{
			return _pricings;
		}

		public IEnumerable<Order> GetOrders()
		{
			return _orders;
		}
	}
}
