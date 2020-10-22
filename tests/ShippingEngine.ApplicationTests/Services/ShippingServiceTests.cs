using FluentAssertions;
using ShippingEngine.Application.Services;
using ShippingEngine.ApplicationTests.Fixtures;
using Xunit;

namespace ShippingEngine.ApplicationTests
{
	public class ShippingServiceTests : IClassFixture<ShippingServiceFixture>
	{
		private readonly ShippingService _shippingService;
		private readonly DataService _dataService;

		public ShippingServiceTests(ShippingServiceFixture pricingServiceFixture)
		{
			_shippingService = pricingServiceFixture.PricingService;
			_dataService = pricingServiceFixture.DataService;
		}

		[Fact]
		public void ImportData_PricingsAreNotEmpty()
		{
			_shippingService.ImportData();

			var pricings = _dataService.GetPricings();

			pricings.Should().NotBeEmpty();
		}

		[Fact]
		public void ImportData_ShipmentsAreNotEmpty()
		{
			_shippingService.ImportData();

			var shipments = _dataService.GetShipments();

			shipments.Should().NotBeEmpty();
		}
	}
}
