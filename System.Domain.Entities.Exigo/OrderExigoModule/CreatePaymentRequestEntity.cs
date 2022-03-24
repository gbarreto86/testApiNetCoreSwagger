using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo.OrderExigoModule
{
    public class CreatePaymentRequestEntity
    {
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public string BillingName { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentType { get; set; }
        public string Memo { get; set; }
    }
}
