using FluentAssertions;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Interfaces;
using ShippingEngine.Domain.Models;
using Xunit;

namespace ShippingEngine.ApplicationTests.Factories
{
    public class DiscountFactoryTests : IClassFixture<DiscountFactoryFixture>
	{
		private readonly IDiscountFactory _discountFactory;

		public DiscountFactoryTests(DiscountFactoryFixture fixture)
		{
			_discountFactory = fixture.DiscountFactory;
		}

		[Theory]
		[InlineData(Sizes.S)]
		[InlineData(Sizes.L)]
		public void Build_GivenValidSize_CreatesValidDiscount(Sizes size)
		{
			var shipment = new Shipment()
			{
				Size = size
			};

			var discount = _discountFactory.Build(shipment);

			discount.Should().NotBeNull();
		}

		[Theory]
		[InlineData(Sizes.M)]
		public void Build_GivenInValid_ReturnsNull(Sizes size)
		{
			var shipment = new Shipment()
			{
				Size = size
			};

			var discount = _discountFactory.Build(shipment);

			discount.Should().BeNull();
		}
	}
}
