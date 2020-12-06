using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Interfaces
{
    public interface IPricingService
    {
        (decimal?, decimal?) CalculatePriceDiscount(Shipment shipment);
        decimal CalculatePrice(Shipment shipment);
    }
}
