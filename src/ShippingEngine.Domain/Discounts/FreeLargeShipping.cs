﻿using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Helpers;
using ShippingEngine.Domain.Interfaces;
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

        public (decimal?, decimal?) CalculatePriceDiscount(Shipment shipment)
        {
            if (shipment.Size == Sizes.L && shipment.Provider == Providers.LP)
            {
                var customerInfo = _dataService.GetDiscountInfo();

                _dataService.IncrementLargeShipments(shipment.Date);

                int count;

                bool outcome = customerInfo.LargeShipmentsTrack.TryGetValue(shipment.Date.RemoveDays(), out count);

                if (outcome && count == 3)
                {
                    return (0, shipment.Price.Value);
                }
            }
            return (shipment.Price, shipment.Discount);
        }
    }
}
