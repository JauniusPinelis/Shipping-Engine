using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IFileService
	{
		IEnumerable<string> ReadShipmentsFile();
		IEnumerable<string> ReadPricingsFile();
	}
}
