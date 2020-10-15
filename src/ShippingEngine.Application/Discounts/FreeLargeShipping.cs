
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Discounts
{
	public class FreeLargeShipping : IDiscount
	{
		private readonly IDataService _dataService;

		public FreeLargeShipping(IDataService dataService)
		{
			_dataService = dataService;
		}

		public Discount ApplyDiscount()
		{
			throw new System.NotImplementedException();
		}
	}
}
