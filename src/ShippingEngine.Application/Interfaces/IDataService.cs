using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDataService
	{
		void ImportOrders();

		void ImportPricings();

		IEnumerable<Shipment> GetShipments();

		IEnumerable<Pricing> GetPricings();

		decimal GetPrice(Provider provider, string size);

		UserInfo GetDiscountInfo();
		void SaveDiscountInfo(DateTime date, decimal discount);
		void TrackLargeShipments(DateTime date);
		void ExportShipments();
		void OverwriteShipments(List<Shipment> orders);
	}
}