using ShippingEngine.Application.Helpers;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Enums;
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
		private readonly List<Shipment> _orders = new List<Shipment>();
		private readonly List<Pricing> _pricings = new List<Pricing>();

		public UserInfo _discountInfo = new UserInfo();

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

		public decimal GetPrice(Provider provider, string size)
		{
			return _pricings.FirstOrDefault(p => p.Provider == provider && p.Size == size).Price;
		}

		public IEnumerable<Shipment> GetOrders()
		{
			return _orders;
		}

		public UserInfo GetDiscountInfo()
		{
			return _discountInfo;
		}

		public void SaveDiscountInfo(DateTime date, decimal discount)
		{
			_discountInfo.AccumulatedDiscountsAMonth
				.Add(new Tuple<DateTime, decimal>(date, discount));
		}

		public void TrackLargeShipments(DateTime date)
		{
			if (_discountInfo.LargeShipmentsTrack.ContainsKey(date))
			{
				_discountInfo.LargeShipmentsTrack[date]++;
			}
			else
			{
				_discountInfo.LargeShipmentsTrack.Add(date, 1);
			}
		}

		public void ExportOrders(List<Shipment> orders)
		{
			var output = orders.Select(o => o.ToString());
			_fileService.WriteToFile(output);
		}
	}
}
