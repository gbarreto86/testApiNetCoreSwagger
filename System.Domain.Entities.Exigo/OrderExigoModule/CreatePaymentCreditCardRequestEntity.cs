using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class CreatePaymentCreditCardRequestEntity
    {
        public int OrderID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public int? CreditCardType { get; set; }
        public string AuthorizationCode { get; set; }
        public string Memo { get; set; }
        public string OrderKey { get; set; }
        public string MerchantTransactionKey { get; set; }    
    }
}
