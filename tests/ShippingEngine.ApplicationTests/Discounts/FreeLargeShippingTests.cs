using FluentAssertions;
using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using System.Linq;
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

			var pricing = _dataService.GetPricings().FirstOrDefault(p => p.Size == size && p.Provider == provider);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Price = pricing.Price,
				Provider = provider,
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(pricing.Price);

			discount.Should().NotHaveValue();
		}

		[Theory]
		[InlineData("L", Providers.LP)]
		public void CalculatePriceDiscount_LargeThirdTransfer_DiscountGetsApplied
			(string size, Providers provider)
		{
			_dataService.ClearDiscounts();
			var date = new DateTime(2000, 1, 1);
			var freeLargeShippping = new FreeLargeShipping(_dataService);
			var pricing = _dataService.GetPricings().FirstOrDefault(p => p.Size == size && p.Provider == provider);


			_dataService.TrackLargeShipments(date);
			_dataService.TrackLargeShipments(date);


			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Price = pricing.Price,
				Provider = provider,
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(0);

			discount.Should().HaveValue();
			discount.Should().Be(pricing.Price);
		}

		[Theory]
		[InlineData("M", Providers.LP)]
		[InlineData("S", Providers.LP)]
		public void CalculatePriceDiscount_NonLargeThirdTransfer_DiscountNotApplied
			(string size, Providers provider)
		{
			var date = new DateTime(2000, 1, 1);
			var freeLargeShippping = new FreeLargeShipping(_dataService);
			var pricing = _dataService.GetPricings().FirstOrDefault(p => p.Size == size && p.Provider == provider);

			_dataService.TrackLargeShipments(date);
			_dataService.TrackLargeShipments(date);


			var shipment = new Shipment()
			{
				Date = date,
				Size = size,
				Price = pricing.Price,
				Provider = provider,
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(pricing.Price);

			discount.Should().NotHaveValue();
		}
	}
}
