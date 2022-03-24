using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class CustomerCreateRequestEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MainCountry { get; set; }
        public bool CanLogin { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public int CustomerType { get; set; }
        public int CustomerStatus { get; set; }
        public bool InsertEnrollerTree { get; set; }
        public int EnrollerID { get; set; }
        public DateTime EntryDate { get; set; }
        public int DefaultWarehouseID { get; set; }
        public string CurrencyCode { get; set; }
        public int LanguageID { get; set; }
    }
}
