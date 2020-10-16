using Microsoft.Extensions.DependencyInjection;
using ShippingEngine.Application.Factories;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<DataService>();
            services.AddScoped<IDiscountFactory, DiscountFactory>();
            services.AddScoped<IDataService, DataService>();

            services.AddScoped<Runner>();

            return services;
        }
    }
}
