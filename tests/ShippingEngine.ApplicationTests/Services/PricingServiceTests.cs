using FluentAssertions;
using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Services;
using ShippingEngine.ApplicationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShippingEngine.ApplicationTests
{
	public class PricingServiceTests : IClassFixture<PricingServiceFixture>
	{
		private readonly PricingService _pricingService;
		private readonly DataService _dataService;

		public PricingServiceTests(PricingServiceFixture pricingServiceFixture)
		{
			_pricingService = pricingServiceFixture.PricingService;
			_dataService = pricingServiceFixture.DataService;
		}

		[Fact]
		public void ImportData_PricingsAreNotEmpty()
		{
			_pricingService.ImportData();

			var pricings = _dataService.GetPricings();

			pricings.Should().NotBeEmpty();
		}

		[Fact]
		public void ImportData_ShipmentsAreNotEmpty()
		{
			_pricingService.ImportData();

			var shipments = _dataService.GetShipments();

			shipments.Should().NotBeEmpty();
		}
	}
}
