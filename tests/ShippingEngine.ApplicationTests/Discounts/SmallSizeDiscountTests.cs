using FluentAssertions;
using ShippingEngine.Application.Discounts;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Interfaces;
using ShippingEngine.Domain.Models;
using System;
using Xunit;

namespace ShippingEngine.ApplicationTests.Discounts
{
    public class SmallSizeDiscountTests : IClassFixture<DataServiceFixture>
	{
		private readonly IDataService _dataService;
		public SmallSizeDiscountTests(DataServiceFixture fixture)
		{
			_dataService = fixture.DataService;
		}

		[Fact]
		public void CalculatePriceDiscount_GivenLargeSize_DoesNotApplyDiscount()
		{
			var size = Sizes.L;
			var provider = Providers.LP;
			var SmallSizeDiscount = new SmallSizeDiscount(_dataService);

			var price = _dataService.GetPrice(provider, size);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Provider = provider,
				Price = price
			};

			var (discountPrice, discount) = SmallSizeDiscount.CalculatePriceDiscount(shipment);

			discountPrice.Should().HaveValue();
			discountPrice.Value.Should().Be(price);

			discount.Should().NotHaveValue();
		}
	}
}

