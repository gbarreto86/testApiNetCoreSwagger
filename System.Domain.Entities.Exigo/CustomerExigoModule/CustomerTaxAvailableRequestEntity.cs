using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class CustomerTaxAvailableRequestEntity
    {
        public string TaxID { get; set; }
        public string CountryCode { get; set; }
        public string DocType { get; set; }
    }
}
