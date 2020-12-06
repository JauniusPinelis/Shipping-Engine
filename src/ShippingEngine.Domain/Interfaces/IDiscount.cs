using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Interfaces
{
    public interface IDiscount
    {
        (decimal?, decimal?) CalculatePriceDiscount(Shipment shipment);
    }
}