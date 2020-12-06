using FluentAssertions;
using ShippingEngine.ApplicationTests.Fixtures;
using ShippingEngine.Domain.Interfaces;
using System;
using System.IO;
using System.Linq;
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
			var pricings = _dataService.GetPricings();

			pricings.Should().NotBeEmpty();
		}

		[Fact]
		public void ImportData_ShipmentsAreNotEmpty()
		{
			var shipments = _dataService.GetShipments();

			shipments.Should().NotBeEmpty();
		}

		[Fact]
		public void ProcessOrders_GivenInputFile_InputMatchesOutput()
		{
			_shippingService.ProcessShipments();

			var shipments = _dataService.GetShipments().ToList();

			var fullPath = Path.Combine(Environment.CurrentDirectory, "Data/ProcessedOrders.txt");
			var outputData = File.ReadAllLines(fullPath).ToList();

			shipments.Count().Should().Be(outputData.Count);

			for (int i = 0; i < shipments.Count(); i++)
			{
				var shipment = shipments[i].ToString();
				var output = outputData[i];

				shipment.Should().Be(output);
			}

		}
	}
}
