using System.Domain.Entities.Exigo;

namespace System.Domain.Entities.Exigo
{
    public class ChargeCreditCardTokenOnFileRequestEntity
    {
        public AccountCreditCardType CreditCardAccountType { get; set; }
        public int OrderID { get; set; }
        public string CvcCode { get; set; }
        public decimal? MaxAmount  { get; set; }
        public int? MerchantWarehouseIDOverride  { get; set; }
        public string ClientIPAddress { get; set; }
        public string OtherData1 { get; set; }
        public string OtherData2 { get; set; }
        public string OtherData3 { get; set; }
        public string OtherData4 { get; set; }
        public string OtherData5 { get; set; }
        public string OtherData6 { get; set; }
        public string OtherData7 { get; set; }
        public string OtherData8 { get; set; }
        public string OtherData9 { get; set; }
        public string OtherData10 { get; set; }
        public string OrderKey { get; set; }
    }
}
