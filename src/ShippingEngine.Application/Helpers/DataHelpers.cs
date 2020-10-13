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
                throw new Exception($"{orderData} is not in the right format");
            }
		}
    }
}
