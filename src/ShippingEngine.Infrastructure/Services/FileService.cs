using ShippingEngine.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ShippingEngine.Application.Services
{
	public class FileService : IFileService
	{
		private const string orderDataFilePath = "Data/Orders.txt";
		private const string pricingDataFilePath = "Data/Pricings.txt";

		public IEnumerable<string> ReadShipmentsFile()
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
			var fullPath2 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			return File.ReadAllLines(fullPath).ToList();
		}
	}
}
