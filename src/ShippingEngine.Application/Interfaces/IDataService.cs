﻿using ShippingEngine.Domain.Models;
using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDataService
	{
		void ImportOrders();

		void ImportPricings();

		IEnumerable<Order> GetOrders();

		IEnumerable<Pricing> GetPricings();

		decimal GetPrice(string provider, string size);

		UserInfo GetDiscountInfo();
		void SaveDiscountInfo(UserInfo discountInfo);


	}
}