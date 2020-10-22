using FluentAssertions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
using Xunit;

namespace ShippingEngine.ApplicationTests
{
	public class ShippingServiceTests : IClassFixture<ShippingServiceFixture>
	{
		private readonly IShippingService _shippingService;
		private readonly IDataService _dataService;

		public ShippingServiceTests(ShippingServiceFixture shippingServiceFixture)
		{
			_shippingService = shippingServiceFixture.ShippingService;
			_dataService = shippingServiceFixture.DataService;
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
