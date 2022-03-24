using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class ValidateAutoOrderRequestEntity
    {
        public int CustomerID { get; set; }
        public bool IncludeCancelledAutoOrders { get; set; }
    }
}
