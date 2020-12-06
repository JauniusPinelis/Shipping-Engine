using ShippingEngine.Domain.Interfaces;
using System;

namespace ShippingEngine.Infrastructure.Services
{
    public class OutputService : IOutputService
    {
        public void ReadLine()
        {
            Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
