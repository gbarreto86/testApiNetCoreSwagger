using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo.CustomerExigoModule
{
    public class UpdateCustomerRequestEntity
    {
        public int CustomerID { get; set; }
        public int? CustomerTypeID { get; set; }
        public string LoginPassword { get; set; }
    }
}
