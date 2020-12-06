using ShippingEngine.Application.Factories;
using ShippingEngine.Domain.Interfaces;

namespace ShippingEngine.ApplicationTests.Fixtures
{
    public class DiscountFactoryFixture : DataServiceFixture
	{
		public IDiscountFactory DiscountFactory { get; set; }

		public DiscountFactoryFixture()
		{
			DiscountFactory = new DiscountFactory(DataService);
		}
	}
}
