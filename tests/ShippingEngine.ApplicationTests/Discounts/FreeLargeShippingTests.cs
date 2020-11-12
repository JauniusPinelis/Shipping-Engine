using FluentAssertions;
using ShippingEngine.Application.Discounts;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
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
		[InlineData(Sizes.S, Providers.LP)]
		[InlineData(Sizes.M, Providers.LP)]
		[InlineData(Sizes.L, Providers.LP)]
		public void CalculatePriceDiscount_NoShipments_DoesNotApplyDiscount
			(Sizes size, Providers provider)
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

			var (discountedPrice, discount) = freeLargeShippping.CalculatePriceDiscount(shipment);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(price);

			discount.Should().NotHaveValue();
		}

		[Theory]
		[InlineData(Sizes.L, Providers.LP)]
		public void CalculatePriceDiscount_LargeThirdTransfer_DiscountGetsApplied
			(Sizes size, Providers provider)
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

			var (discountedPrice, discount) = freeLargeShippping.CalculatePriceDiscount(shipment);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(0);

			discount.Should().HaveValue();
			discount.Should().Be(price);
		}

		[Theory]
		[InlineData(Sizes.M, Providers.LP)]
		[InlineData(Sizes.S, Providers.LP)]
		public void CalculatePriceDiscount_NonLargeThirdTransfer_DiscountNotApplied
			(Sizes size, Providers provider)
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

			var (discountedPrice, discount) = freeLargeShippping.CalculatePriceDiscount(shipment);

			discountedPrice.Should().HaveValue();
			discountedPrice.Value.Should().Be(price);

			discount.Should().NotHaveValue();
		}
	}
}
