using System.Collections.Generic;
using System.Domain.Entities.Exigo;

namespace System.Domain.Entities.Exigo
{
    public class CreateAutoOrderRequestEntity
    {
        public int CustomerID { get; set; }
        public FrequencyType Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public int? SpecificDayInterval { get; set; }
        public string CurrencyCode { get; set; }
        public int WarehouseID { get; set; }
        public int ShipMethodID { get; set; }
        public int PriceType { get; set; }
        public AutoOrderPaymentType PaymentType { get; set; }
        public AutoOrderProcessType? ProcessType { get; set; }
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
        public string Description { get; set; }
        public bool OverwriteExistingAutoOrder { get; set; }
        public int ExistingAutoOrderID { get; set; }
        public List<OrderDetailRequestEntity> Details { get; set; }
        public string CustomerKey { get; set; }
    }
}
