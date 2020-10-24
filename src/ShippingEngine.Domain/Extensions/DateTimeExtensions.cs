using System;

namespace ShippingEngine.Domain.Helpers
{
	public static class DateTimeExtensions
	{
		public static DateTime RemoveDays(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, 1);
		}
	}
}
