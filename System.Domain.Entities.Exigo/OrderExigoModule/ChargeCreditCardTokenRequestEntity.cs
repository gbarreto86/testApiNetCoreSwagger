using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class ChargeCreditCardTokenRequestEntity
    {
        public string CreditCardToken { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public string CvcCode { get; set; }
        public string IssueNumber { get; set; }
        public int? CreditCardType { get; set; }
        public int? ExpirationMonth { get; set; }
        public int? ExpirationYear { get; set; }
        public int OrderID { get; set; }
        public decimal? MaxAmount { get; set; }
        public int? MerchantWarehouseIDOverride { get; set; }
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
