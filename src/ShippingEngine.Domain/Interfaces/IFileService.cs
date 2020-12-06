using System.Collections.Generic;

namespace ShippingEngine.Domain.Interfaces
{
    public interface IFileService
    {
        IEnumerable<string> ReadShipmentsFile();
        IEnumerable<string> ReadPricingsFile();
    }
}
