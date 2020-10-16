using System;
using System.Collections.Generic;
using System.Text;

namespace ShippingEngine.Domain.Models
{
	public class Shipment
	{
		public DateTime Date { get; set; }
		public string Provider { get; set; }
		public string Size { get; set; }

		public bool Valid { get; set; } = true;

		public decimal? Price { get; set; }
		public decimal? Discount { get; set; }

		public override string ToString()
		{
			return $"{Date} {Size} {Provider} {Price} {Discount}";
		}
	}
}
