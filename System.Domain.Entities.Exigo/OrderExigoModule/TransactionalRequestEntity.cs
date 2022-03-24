using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class TransactionalRequestEntity
    {
       public CreateCustomerRequestEntity CreateCustomerRequest { get; set; }
       public CreateOrderRequestEntity CreateOrderRequest { get; set; }
       public CreatePaymentCreditCardRequestEntity CreatePaymentCreditCardRequest { get; set; }
       public CreateAutoOrderRequestEntity CreateAutoOrderRequest { get; set; }
       public SetAccountCreditCardRequestEntity SetAccountCreditCardRequest { get; set; }
       public ChargeCreditCardTokenRequestEntity ChargeCreditCardTokenRequest { get; set; }
       public ChargeCreditCardTokenOnFileRequestEntity ChargeCreditCardTokenOnFileRequest { get; set; }
    }
}
