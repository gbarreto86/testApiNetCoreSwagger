using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class OrderDetailRequestEntity
    {
        public string ItemCode { get; set; }
        public Guid? OrderDetailID { get; set; }
        public Guid? ParentOrderDetailID { get; set; }
        public decimal Quantity { get; set; }
        public string ParentItemCode { get; set; }
        public decimal? PriceEachOverride { get; set; }
        public decimal? TaxableEachOverride { get; set; }
        public decimal? ShippingPriceEachOverride { get; set; }
        public decimal? BusinessVolumeEachOverride { get; set; }
        public decimal? CommissionableVolumeEachOverride { get; set; }
        public decimal? Other1EachOverride { get; set; }
        public decimal? Other2EachOverride { get; set; }
        public decimal? Other3EachOverride { get; set; }
        public decimal? Other4EachOverride { get; set; }
        public decimal? Other5EachOverride { get; set; }
        public decimal? Other6EachOverride { get; set; }
        public decimal? Other7EachOverride { get; set; }
        public decimal? Other8EachOverride { get; set; }
        public decimal? Other9EachOverride { get; set; }
        public decimal? Other10EachOverride { get; set; }
        public string DescriptionOverride { get; set; }
        public string Reference1 { get; set; }
        public AdvancedAutoOptionsRequestEntity AdvancedAutoOptions { get; set; }
    }
}
