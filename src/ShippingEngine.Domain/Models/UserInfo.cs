using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Domain.Models
{
    public class UserInfo
    {
        public List<Tuple<DateTime, decimal>> AccumulatedDiscountsAMonth { get; set; }

        public Dictionary<DateTime, int> LargeShipmentsAmonth { get; set; }
    }
}
