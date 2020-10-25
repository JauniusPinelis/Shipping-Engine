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
	public class FreeLargeShippingTests : IClassFixture<DiscountFixture>
	{
		private readonly IDataService _dataService;
		public FreeLargeShippingTests(DiscountFixture fixture)
		{
			_dataService = fixture.DataService;
		}

		[Fact]
		public void CalculatePriceDiscount_GivenSmallSize_DoesNotApplyDiscount()
		{
			var freeLargeShippping = new FreeLargeShipping(_dataService);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = "S",
				Provider = Provider.LP,
				Price = 2
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(2);

			discount.Should().NotHaveValue();
		}


		[Fact]
		public void CalculatePriceDiscount_GivenLargeSizeWith0TransfersThisMonths_DoesNotApplyDiscount()
		{
			var freeLargeShippping = new FreeLargeShipping(_dataService);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = "L",
				Provider = Provider.LP,
				Price = 2
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(2);

			discount.Should().NotHaveValue();
		}

		[Fact]
		public void CalculatePriceDiscount_ThisLargeTransfer_DiscountGetsApplied()
		{
			var freeLargeShippping = new FreeLargeShipping(_dataService);

			_dataService.TrackLargeShipments(new DateTime(2000, 1, 1));
			_dataService.TrackLargeShipments(new DateTime(2000, 1, 1));


			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = "L",
				Provider = Provider.LP,
				Price = 2
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(0);

			discount.Should().HaveValue();
			discount.Should().Be(2);
		}
	}
}
