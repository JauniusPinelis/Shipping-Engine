using ShippingEngine.Domain.Interfaces;
using System;

namespace ShippingEngine.Application
{
    public class Runner
    {
        private readonly IShippingService _shippingService;
        private readonly IDataService _dataService;

        public Runner(IShippingService shippingService, IDataService dataService)
        {
            _shippingService = shippingService;
            _dataService = dataService;
        }

        public void Run()
        {
            _dataService.SetupData();

            _shippingService.ProcessShipments();

            DisplayResults();
        }

        private void DisplayResults()
        {
            var shipments = _dataService.GetShipments();

            foreach (var shipment in shipments)
            {
                Console.WriteLine(shipment.ToString());
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
