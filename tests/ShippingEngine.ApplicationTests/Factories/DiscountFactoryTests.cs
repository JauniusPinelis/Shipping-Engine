using FluentAssertions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
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
		[InlineData("S")]
		[InlineData("L")]
		public void Build_GivenValidSize_CreatesValidDiscount(string size)
		{
			var shipment = new Shipment()
			{
				Size = size
			};

			var discount = _discountFactory.Build(shipment);

			discount.Should().NotBeNull();
		}

		[Theory]
		[InlineData("R")]
		public void Build_GivenInValid_ReturnsNull(string size)
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
