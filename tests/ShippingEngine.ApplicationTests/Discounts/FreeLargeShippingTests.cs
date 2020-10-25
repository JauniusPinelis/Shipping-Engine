using FluentAssertions;
using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using Xunit;

namespace ShippingEngine.ApplicationTests.Discounts
{
	public class FreeLargeShippingTests : IClassFixture<DataServiceFixture>
	{
		private readonly IDataService _dataService;
		public FreeLargeShippingTests(DataServiceFixture fixture)
		{
			_dataService = fixture.DataService;
		}

		[Theory]
		[InlineData("S", Providers.LP)]
		[InlineData("M", Providers.LP)]
		[InlineData("L", Providers.LP)]
		public void CalculatePriceDiscount_NoShipments_DoesNotApplyDiscount
			(string size, Providers provider)
		{
			var freeLargeShippping = new FreeLargeShipping(_dataService);

			var price = _dataService.GetPrice(provider, size);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Price = price,
				Provider = provider,
			};

			var (discountedPrice, discount) = shipment.Apply(freeLargeShippping);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(price);

			discount.Should().NotHaveValue();
		}

		[Theory]
		[InlineData("L", Providers.LP)]
		public void CalculatePriceDiscount_LargeThirdTransfer_DiscountGetsApplied
			(string size, Providers provider)
		{
			_dataService.ClearUserInfo();
			var date = new DateTime(2000, 1, 1);
			var freeLargeShippping = new FreeLargeShipping(_dataService);
			var price = _dataService.GetPrice(provider, size);


			_dataService.IncrementLargeShipments(date);
			_dataService.IncrementLargeShipments(date);


			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Price = price,
				Provider = provider,
			};

			var (discountedPrice, discount) = shipment.Apply(freeLargeShippping);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(0);

			discount.Should().HaveValue();
			discount.Should().Be(price);
		}

		[Theory]
		[InlineData("M", Providers.LP)]
		[InlineData("S", Providers.LP)]
		public void CalculatePriceDiscount_NonLargeThirdTransfer_DiscountNotApplied
			(string size, Providers provider)
		{
			var date = new DateTime(2000, 1, 1);
			var freeLargeShippping = new FreeLargeShipping(_dataService);
			var price = _dataService.GetPrice(provider, size);

			_dataService.IncrementLargeShipments(date);
			_dataService.IncrementLargeShipments(date);


			var shipment = new Shipment()
			{
				Date = date,
				Size = size,
				Price = price,
				Provider = provider,
			};

			var (discountedPrice, discount) = shipment.Apply(freeLargeShippping);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(price);

			discount.Should().NotHaveValue();
		}
	}
}
