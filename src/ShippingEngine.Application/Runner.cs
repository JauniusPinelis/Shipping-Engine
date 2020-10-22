using ShippingEngine.Application.Interfaces;

namespace ShippingEngine.Application
{
	public class Runner
	{
		private readonly IShippingService _shippingService;

		public Runner(IShippingService shippingService)
		{
			_shippingService = shippingService;
		}

		public void Run()
		{
			_shippingService.ImportData();
			_shippingService.ProcessShipments();
		}
	}
}
