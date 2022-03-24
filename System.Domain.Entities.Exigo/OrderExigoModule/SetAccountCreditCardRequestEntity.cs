using System.Domain.Entities.Exigo;

namespace System.Domain.Entities.Exigo
{
    public class SetAccountCreditCardRequestEntity
    {
        public int CustomerID { get; set; }
        public AccountCreditCardType CreditCardAccountType { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CvcCode { get; set; }
        public string IssueCode { get; set; }
        public int? CreditCardType { get; set; }
        public string BillingName { get; set; }
        public bool UseMainAddress { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public bool? HideFromWeb { get; set; }
        public string CustomerKey { get; set; }
    }
}
