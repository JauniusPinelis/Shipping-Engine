using Microsoft.Extensions.DependencyInjection;
using ShippingEngine.Application.Services;
using ShippingEngine.Domain.Factories;
using ShippingEngine.Domain.Interfaces;
using ShippingEngine.Domain.Services;

namespace ShippingEngine.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<DataService>();
            services.AddScoped<IDiscountFactory, DiscountFactory>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPricingService, PricingService>();

            services.AddScoped<Runner>();

            return services;
        }
    }
}
