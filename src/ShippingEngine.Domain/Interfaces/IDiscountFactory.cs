using ShippingEngine.Domain.Models;

namespace ShippingEngine.Domain.Interfaces
{
    public interface IDiscountFactory
    {
        IDiscount Build(Shipment shipment);
    }
}