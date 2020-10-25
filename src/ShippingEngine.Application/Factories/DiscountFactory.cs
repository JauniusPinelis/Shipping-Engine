﻿using ShippingEngine.Application.Discounts;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Application.Factories
{
	public class DiscountFactory : IDiscountFactory
	{
		private readonly IDataService _dataService;

		public DiscountFactory(IDataService dataService)
		{
			_dataService = dataService;
		}

		public IDiscount Build(Shipment shipment)
		{
			if (shipment.Size == Sizes.S)
			{
				return new SmallSizeDiscount(_dataService);
			}
			if (shipment.Size == Sizes.L)
			{
				return new FreeLargeShipping(_dataService);
			}

			return null;
		}
	}
}
