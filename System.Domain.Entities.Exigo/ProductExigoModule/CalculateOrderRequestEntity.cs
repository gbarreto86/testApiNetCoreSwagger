using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class CalculateOrderRequestEntity
    {
        public int CustomerID { get; set; }
        public decimal? ShippingAmountOverride { get; set; }
        public int WarehouseID { get; set; }
        public string CurrencyCode { get; set; }
        public int PriceType { get; set; }
        public int ShipMethodID { get; set; }
        public bool ReturnShipMethods { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public int? PartyID { get; set; }

        public OrderDetailEntity[] ListOrderDetail { get; set; }
    }

    public class OrderDetailEntity
    {
        public string ItemCode { get; set; }

        public decimal Quantity { get; set; }
    }
}
