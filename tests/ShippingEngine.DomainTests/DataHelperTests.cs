using FluentAssertions;
using ShippingEngine.Domain.Helpers;
using System;
using Xunit;

namespace ShippingEngine.DomainTests
{
    public class DataHelperTests
    {
        [Theory]
        [InlineData("2015-02-10 K LP")]
        [InlineData("2015-02-10 S MR")]
        public void ParseShipment_GivenCorrectFormat_ParsesShipment(string shipmentData)
        {
            var shipment = DataHelpers.ParseShipment(shipmentData);

            shipment.Valid.Should().BeTrue();
            shipment.ErrorMessage.Should().BeNull();
        }

        [Theory]
        [InlineData("2015-02-29 CUSPS Ignored")]
        public void ParseShipment_GivenIncorrectFormat_ParsesShipment(string shipmentData)
        {
            var shipment = DataHelpers.ParseShipment(shipmentData);

            shipment.Valid.Should().BeFalse();
            shipment.ErrorMessage.Should().NotBeNull();
        }

        [Theory]
        [InlineData("LP L 6.90")]
        [InlineData("LP L 5")]
        public void ParsePricing_GivenCorrectFormat_ParsesPricing(string pricingData)
        {
            var pricing = DataHelpers.ParsePricing(pricingData);

            pricing.Should().NotBeNull();
        }

        [Theory]
        [InlineData("DP L 6.90")]
        public void ParsePricing_GiveninCorrectFormat_ParsesPricing(string pricingData)
        {
            Action act = () => DataHelpers.ParsePricing(pricingData);

            act.Should().Throw<Exception>();
        }

    }
}
