using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Interfaces
{
	public interface IPricingService
	{
		void ImportData();
		void ProcessShipments();
	}
}
