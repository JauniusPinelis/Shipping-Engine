using Microsoft.Extensions.DependencyInjection;
using ShippingEngine.Application;

namespace ShippingEngine
{
	public class Program
	{
		static void Main(string[] args)
		{
			var services = DependencyInjection.ConfigureServices();

			var serviceProvider = services.BuildServiceProvider();

			serviceProvider.GetService<Runner>().Run();
		}
	}
}
