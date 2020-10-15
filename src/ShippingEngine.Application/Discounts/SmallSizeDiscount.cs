using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Discounts;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Discounts
{
	public class SmallSizeDiscount : IDiscount
	{
		private readonly IDataService _dataService;

		public SmallSizeDiscount(IDataService dataService)
		{
			_dataService = dataService;
		}

		public Discount ApplyDiscount()
		{
			throw new NotImplementedException();
		}
	}
}
