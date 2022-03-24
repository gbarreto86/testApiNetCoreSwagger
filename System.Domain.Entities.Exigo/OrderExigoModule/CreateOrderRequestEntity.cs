using System.Collections.Generic;

namespace System.Domain.Entities.Exigo
{
    public class CreateOrderRequestEntity
    {
        public int CustomerID { get; set; }
        public OrderStatusType OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string CurrencyCode { get; set; }
        public int WarehouseID { get; set; }
        public int ShipMethodID { get; set; }
        public int PriceType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Other11 { get; set; }
        public string Other12 { get; set; }
        public string Other13 { get; set; }
        public string Other14 { get; set; }
        public string Other15 { get; set; }
        public string Other16 { get; set; }
        public string Other17 { get; set; }
        public string Other18 { get; set; }
        public string Other19 { get; set; }
        public string Other20 { get; set; }
        public OrderType OrderType { get; set; }
        public decimal? TaxRateOverride { get; set; }
        public decimal? ShippingAmountOverride { get; set; }
        public bool? UseManualOrderID { get; set; }
        public int? ManualOrderID { get; set; }
        public int? TransferVolumeToID { get; set; }
        public int? ReturnOrderID { get; set; }
        public bool OverwriteExistingOrder { get; set; }
        public int ExistingOrderID { get; set; }
        public int? PartyID { get; set; }
        public List<OrderDetailRequestEntity> Details { get; set; }
        public bool SuppressPackSlipPrice { get; set; }
        public string TransferVolumeToKey { get; set; }
        public string ReturnOrderKey { get; set; }
        public string ManualOrderKey { get; set; }
        public string ExistingOrderKey { get; set; }
        public string CustomerKey { get; set; }
    }
}
