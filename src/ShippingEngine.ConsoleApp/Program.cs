using Microsoft.Extensions.DependencyInjection;
using ShippingEngine.Application;
using System;

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
