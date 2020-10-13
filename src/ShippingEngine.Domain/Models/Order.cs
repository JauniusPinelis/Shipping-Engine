using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingEngine.Domain.Models
{
	public class Order
	{
		public DateTime Date { get; set; }
		public string Provider { get; set; }
		public string Size { get; set; }
	}
}
