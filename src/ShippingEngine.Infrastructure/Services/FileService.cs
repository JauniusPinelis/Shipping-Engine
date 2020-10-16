using ShippingEngine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Services
{
    public class FileService : IFileService
    {
        private const string orderDataFilePath = "Data/Input.txt";
        private const string pricingDataFilePath = "Data/Pricings.txt";

        private const string orderOutputFilePath = "Data/Orders.txt";

        public IEnumerable<string> ReadOrderData()
	    {
            return ReadData(orderDataFilePath);
        }

        public IEnumerable<string> ReadPricingData()
		{
            return ReadData(pricingDataFilePath);
        }

        private IEnumerable<string> ReadData(string filePath)
		{
            var fullPath = Path.Combine(Environment.CurrentDirectory, filePath);
            return File.ReadAllLines(fullPath).ToList();
        }

        public void WriteToFile(IEnumerable<string> lines)
		{
            var fullPath = Path.Combine(Environment.CurrentDirectory, orderOutputFilePath);
            System.IO.File.WriteAllLines(fullPath, lines);
        }
    }
}
