using ShippingEngine.Domain.Models;
using System.Collections.Generic;

namespace ShippingEngine.Application.Interfaces
{
	public interface IDataService
	{
		void ImportOrders();

		void ImportPricings();

		IEnumerable<Order> GetOrders();

		IEnumerable<Pricing> GetPricings();
	}
}