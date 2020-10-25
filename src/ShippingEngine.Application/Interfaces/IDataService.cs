using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDataService
	{
		void ImportShipments();

		void ImportPricings();

		IEnumerable<Shipment> GetShipments();

		IEnumerable<Pricing> GetPricings();

		decimal GetPrice(Providers provider, Sizes size);

		UserInfo GetDiscountInfo();
		void IncrementAccumulatedDiscounts(DateTime date, decimal discount);
		void IncrementLargeShipments(DateTime date);
		void OverwriteShipments(List<Shipment> orders);
		void ClearUserInfo();
	}
}