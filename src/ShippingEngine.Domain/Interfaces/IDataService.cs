using ShippingEngine.Domain.Enums;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;

namespace ShippingEngine.Domain.Interfaces
{
    public interface IDataService
    {

        IEnumerable<Shipment> GetShipments();

        IEnumerable<Pricing> GetPricings();

        decimal GetPrice(Providers provider, Sizes size);

        UserInfo GetDiscountInfo();
        void IncrementAccumulatedDiscounts(DateTime date, decimal discount);
        void IncrementLargeShipments(DateTime date);
        void OverwriteShipments(List<Shipment> shipments);
        void ClearUserInfo();
        void SetupData();
    }
}