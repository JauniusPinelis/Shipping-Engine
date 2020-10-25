using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Helpers;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShippingEngine.Application.Services
{
	public class DataService : IDataService
	{
		private List<Shipment> _shipments = new List<Shipment>();
		private readonly List<Pricing> _pricings = new List<Pricing>();

		private readonly IFileService _fileService;

		public UserInfo _discountInfo = new UserInfo();

		public DataService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public void ImportShipments()
		{
			var shipmentData = _fileService.ReadShipmentsFile();

			var shipments = shipmentData.Select(o => DataHelpers.ParseShipment(o));

			_shipments.AddRange(shipments);
		}

		public void ImportPricings()
		{
			var pricingData = _fileService.ReadPricingsFile();

			var pricings = pricingData.Select(p => DataHelpers.ParsePricing(p));

			_pricings.AddRange(pricings);
		}

		public decimal GetPrice(Providers provider, Sizes size)
		{
			return _pricings.FirstOrDefault(p => p.Provider == provider && p.Size == size).Price;
		}

		public IEnumerable<Pricing> GetPricings()
		{
			return _pricings;
		}

		public IEnumerable<Shipment> GetShipments()
		{
			return _shipments;
		}

		public UserInfo GetDiscountInfo()
		{
			return _discountInfo;
		}

		public void IncrementAccumulatedDiscounts(DateTime date, decimal discount)
		{
			_discountInfo.AccumulatedDiscountsAMonth
				.Add(new Tuple<DateTime, decimal>(date, discount));
		}

		public void IncrementLargeShipments(DateTime date)
		{
			date = date.RemoveDays();
			if (_discountInfo.LargeShipmentsTrack.ContainsKey(date))
			{
				_discountInfo.LargeShipmentsTrack[date]++;
			}
			else
			{
				_discountInfo.LargeShipmentsTrack.Add(date, 1);
			}
		}

		public void OverwriteShipments(List<Shipment> shipments)
		{
			_shipments = shipments;
		}

		public void ClearUserInfo()
		{
			_discountInfo = new UserInfo();
		}
	}
}
