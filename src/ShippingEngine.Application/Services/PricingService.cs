﻿using ShippingEngine.Application.Extensions;
using ShippingEngine.Application.Interfaces;
using ShippingEngine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingEngine.Application.Services
{
    public class PricingService : IPricingService
    {
		private readonly IDataService _dataService;
		private readonly IDiscountFactory _discountFactory;

		public PricingService( IDataService dataService, 
			IDiscountFactory discountFactory)
		{
			_dataService = dataService;
			_discountFactory = discountFactory;
		}

		public void ProcessShipments()
		{
			var orders = _dataService.GetOrders().ToList();

			foreach (var order in orders.Where(o => o.Valid))
				ProcessShipment(order);

			_dataService.ExportOrders(orders);
		}

		public void ImportData()
		{
			_dataService.ImportOrders();
			_dataService.ImportPricings();
		}

		private void ProcessShipment(Shipment shipment)
		{
			shipment.Price = _dataService.GetPrice(shipment.Provider, shipment.Size);

			ApplyDiscount(shipment);

			if (shipment.Size == "L")
			{
				_dataService.TrackLargeShipments(shipment.Date);
			}
		}

		private void ApplyDiscount(Shipment shipment)
		{
			var discount = _discountFactory.Build(shipment);
			if (discount != null)
			{
				shipment.Apply(discount);
			}
		}

		public void ExportData()
		{

		}
    }
}