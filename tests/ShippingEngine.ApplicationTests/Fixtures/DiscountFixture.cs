using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;

namespace ShippingEngine.ApplicationTests.Fixtures
{
	public class DiscountFixture
	{
		public readonly IDataService DataService;

		public DiscountFixture()
		{
			var _fileService = new FileService();
			DataService = new DataService(_fileService);

			DataService.ImportPricings();
		}
	}
}
