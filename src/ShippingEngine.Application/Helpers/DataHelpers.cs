using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Helpers
{
    public static class DataHelpers
    {
        public static Order ParseOrder(string orderData)
		{
            try
			{
                var elements = orderData.Split(' ');

                return new Order()
                {
                    Date = DateTime.Parse(elements[0]),
                    Size = elements[1],
                    Provider = elements[2]
                };
            }
            catch(Exception)
			{
                return new Order()
                {
                    Valid = false
                };
            }
		}

        public static Pricing ParsePricing(string pricingData)
		{
            try
			{
                var elements = pricingData.Split(' ');

                return new Pricing()
                {
                    Provider = elements[0],
                    Size = elements[1],
                    Price = Decimal.Parse(elements[2])
                };
            }
			catch (Exception)
			{
                throw new Exception($"Pricing {pricingData} has incorrect format");
			}
		}
    }
}
