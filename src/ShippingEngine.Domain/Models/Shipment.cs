using ShippingEngine.Domain.Enums;
using System;

namespace ShippingEngine.Domain.Models
{
	public class Shipment
	{
		public DateTime Date { get; set; }
		public Provider Provider { get; set; }
		public string Size { get; set; }

		public bool Valid { get; set; } = true;

		public decimal? Price { get; set; }
		public decimal? Discount { get; set; }

		public override string ToString()
		{
			return $"{Date:yyyy-MM-dd} {Size} {Provider} {(Price.HasValue ? Price.Value.ToString("F") : "0.00")} {(Discount == 0 ? "-" : Discount.ToString())}";
		}
	}
}
