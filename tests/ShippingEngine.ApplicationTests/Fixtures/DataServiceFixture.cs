using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;

namespace ShippingEngine.ApplicationTests.Fixtures
{
	public class DataServiceFixture
	{
		public readonly IDataService DataService;

		public DataServiceFixture()
		{
			var _fileService = new FileService();
			DataService = new DataService(_fileService);

			DataService.ImportPricings();
		}
	}
}
