using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Interfaces
{
    public interface IFileService
    {
        IEnumerable<string> ReadOrderData();
        IEnumerable<string> ReadPricingData();

        void WriteToFile(IEnumerable<string> lines);
    }
}
