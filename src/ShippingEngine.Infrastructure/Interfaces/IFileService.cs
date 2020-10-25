using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IFileService
	{
		IEnumerable<string> ReadOrdersFile();
		IEnumerable<string> ReadPricingsFile();
	}
}
