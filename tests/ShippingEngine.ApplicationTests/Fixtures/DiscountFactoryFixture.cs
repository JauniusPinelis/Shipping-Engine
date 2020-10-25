using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Interfaces;

namespace ShippingEngine.ApplicationTests.Fixtures
{
	public class DiscountFactoryFixture : DataServiceFixture
	{
		public IDiscountFactory DiscountFactory { get; set; }

		public DiscountFactoryFixture() : base()
		{
			DiscountFactory = new DiscountFactory(DataService);
		}
	}
}
