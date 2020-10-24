using ShippingEngine.Application.Interfaces;
using ShippingEngine.ApplicationTests.Fixtures;
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

		public
	}
}
