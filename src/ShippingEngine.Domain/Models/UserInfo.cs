using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Domain.Models
{
    public class UserInfo
    {
        public List<Tuple<DateTime, decimal>> AccumulatedDiscountsAMonth { get; set; } = new List<Tuple<DateTime, decimal>>();

        public Dictionary<DateTime, int> LargeShipmentsTrack { get; set; } = new Dictionary<DateTime, int>();
    }
}
