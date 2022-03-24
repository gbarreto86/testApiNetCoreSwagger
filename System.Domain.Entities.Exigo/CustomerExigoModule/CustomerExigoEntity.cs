using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class CustomerExigoEntity
    {

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }  
        public string LoginName { get; set; }
        public int CustomerTypeID { get; set; }
        public int CustomerStatusID { get; set; }
        public int LanguageID { get; set; }
        public int DefaultWarehouseID { get; set; }
        public string CurrencyCode { get; set; } 
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }
}
