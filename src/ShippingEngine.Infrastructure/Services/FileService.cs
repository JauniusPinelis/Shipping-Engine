using ShippingEngine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShippingEngine.Application.Services
{
	public class FileService : IFileService
	{
		private const string orderDataFilePath = "Data/Orders.txt";
		private const string pricingDataFilePath = "Data/Pricings.txt";

		private const string orderOutputFilePath = "Data/ProcessedOrders.txt";

		public IEnumerable<string> ReadOrdersFile()
		{
			return ReadData(orderDataFilePath);
		}

		public IEnumerable<string> ReadPricingsFile()
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
