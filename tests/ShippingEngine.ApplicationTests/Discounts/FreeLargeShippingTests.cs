using FluentAssertions;
using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Models;
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
				Size = "Small",
				Price = 2
			};

			var (price, discount) = shipment.Apply(freeLargeShippping);

			price.Should().HaveValue();
			price.Value.Should().Be(2);

			discount.Should().NotHaveValue();
		}
	}
}
