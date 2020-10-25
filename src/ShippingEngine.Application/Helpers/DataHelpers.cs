﻿using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Extensions;
using ShippingEngine.Domain.Models;
using System;

namespace ShippingEngine.Application.Helpers
{
	public static class DataHelpers
	{
		public static Shipment ParseOrder(string orderData)
		{
			try
			{
				var elements = orderData.Split(' ');

				return new Shipment()
				{
					Date = DateTime.Parse(elements[0]),
					Size = elements[1],
					Provider = elements[2].ToEnum<Providers>()
				};
			}
			catch (Exception ex)
			{
				return new Shipment()
				{
					ErrorMessage = orderData + " Ignored",
					Valid = false
				};
			}
		}

		public static Pricing ParsePricing(string pricingData)
		{
			try
			{
				var elements = pricingData.Split(' ');

				return new Pricing()
				{
					Provider = elements[0].ToEnum<Providers>(),
					Size = elements[1],
					Price = Decimal.Parse(elements[2])
				};
			}
			catch (Exception)
			{
				throw new Exception($"Pricing {pricingData} has incorrect format");
			}
		}
	}
}
