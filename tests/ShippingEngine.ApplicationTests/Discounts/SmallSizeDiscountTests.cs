using FluentAssertions;
using ShippingEngine.Application.Discounts;
using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using System.Linq;
using Xunit;

namespace ShippingEngine.ApplicationTests.Discounts
{
	public class SmallSizeDiscountTests : IClassFixture<DiscountFixture>
	{
		private readonly IDataService _dataService;
		public SmallSizeDiscountTests(DiscountFixture fixture)
		{
			_dataService = fixture.DataService;
		}

		[Fact]
		public void CalculatePriceDiscount_GivenLargeSize_DoesNotApplyDiscount()
		{
			var size = "L";
			var provider = Providers.LP;
			var SmallSizeDiscount = new SmallSizeDiscount(_dataService);

			var pricing = _dataService.GetPricings().FirstOrDefault(p => p.Size == size && p.Provider == provider);

			var shipment = new Shipment()
			{
				Date = new DateTime(2000, 1, 1),
				Size = size,
				Provider = provider,
				Price = pricing.Price
			};

			var (price, discount) = shipment.Apply(SmallSizeDiscount);

			price.Should().HaveValue();
			price.Value.Should().Be(pricing.Price);

			discount.Should().NotHaveValue();
		}
	}
}

