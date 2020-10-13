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
        private const string inputPath = "Data/input.txt";
        private const string outputName = "output.txt";

        public IEnumerable<string> ReadInputFile()
	    {
            var filePath = Path.Combine(Environment.CurrentDirectory, inputPath);
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
