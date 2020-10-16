﻿using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;
using ShippingEngine.Domain.Discounts;
using System;
using ShippingEngine.Application.Discounts;
using ShippingEngine.Application.Services;

namespace ShippingEngine.Application.Factories
{
	public class DiscountFactory : IDiscountFactory
	{
		private readonly IDataService _dataService;

		public DiscountFactory(IDataService dataService)
		{
			_dataService = dataService;
		}

		public IDiscount Build(Shipment order)
		{
			if (order.Size == "S")
			{
				return new SmallSizeDiscount(_dataService);
			}
			if (order.Size == "L")
			{
				return new FreeLargeShipping(_dataService);
			}

			return null;
		}
	}
}