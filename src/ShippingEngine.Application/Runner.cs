using ShippingEngine.Domain.Interfaces;

namespace ShippingEngine.Application
{
    public class Runner
    {
        private readonly IShippingService _shippingService;
        private readonly IDataService _dataService;
        private readonly IOutputService _outputService;

        public Runner(IShippingService shippingService, IDataService dataService, IOutputService outputService)
        {
            _shippingService = shippingService;
            _dataService = dataService;
            _outputService = outputService;
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
                _outputService.WriteLine(shipment.ToString());
            }

            _outputService.WriteLine("Press any key to exit");
            _outputService.ReadLine();
        }
    }
}
