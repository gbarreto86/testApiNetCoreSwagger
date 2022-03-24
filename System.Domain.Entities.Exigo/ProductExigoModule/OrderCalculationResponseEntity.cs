using System;
using System.Collections.Generic;
using System.Text;

namespace System.Domain.Entities.Exigo
{
    public class OrderCalculationResponseEntity
    {
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal BV { get; set; }
        public decimal CV { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal FedTaxTotal { get; set; }
        public decimal StateTaxTotal { get; set; }

        public IEnumerable<ShipMethodEntity> ShipMethods { get; set; }

        public IEnumerable<OrderDetailResponseEntity> Details { get; set; }
        public decimal DiscountFromExigo { get; set; }
    }


    public class OrderDetailResponseEntity
    {
        private string itemCodeField;

        private string descriptionField;

        private decimal quantityField;

        private decimal priceEachField;

        private decimal priceTotalField;

        private decimal taxField;

        private decimal weightEachField;

        private decimal weightField;

        private decimal businessVolumeEachField;

        private decimal businesVolumeField;

        private decimal commissionableVolumeEachField;

        private decimal commissionableVolumeField;

        private decimal other1EachField;

        private decimal other1Field;

        private decimal other2EachField;

        private decimal other2Field;

        private decimal other3EachField;

        private decimal other3Field;

        private decimal other4EachField;

        private decimal other4Field;

        private decimal other5EachField;

        private decimal other5Field;

        private decimal other6EachField;

        private decimal other6Field;

        private decimal other7EachField;

        private decimal other7Field;

        private decimal other8EachField;

        private decimal other8Field;

        private decimal other9EachField;

        private decimal other9Field;

        private decimal other10EachField;

        private decimal other10Field;

        private string parentItemCodeField;

        private decimal taxableField;

        private decimal fedTaxField;

        private decimal stateTaxField;

        private decimal cityTaxField;

        private decimal cityLocalTaxField;

        private decimal countyTaxField;

        private decimal countyLocalTaxField;

        private decimal manualTaxField;

        private bool isStateTaxOverrideField;

        private int orderLineField;

        private string reference1Field;

        private decimal shippingPriceEachField;

        /// <remarks/>
        public string ItemCode
        {
            get
            {
                return this.itemCodeField;
            }
            set
            {
                this.itemCodeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public decimal Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        public decimal PriceEach
        {
            get
            {
                return this.priceEachField;
            }
            set
            {
                this.priceEachField = value;
            }
        }

        /// <remarks/>
        public decimal PriceTotal
        {
            get
            {
                return this.priceTotalField;
            }
            set
            {
                this.priceTotalField = value;
            }
        }

        /// <remarks/>
        public decimal Tax
        {
            get
            {
                return this.taxField;
            }
            set
            {
                this.taxField = value;
            }
        }

        /// <remarks/>
        public decimal WeightEach
        {
            get
            {
                return this.weightEachField;
            }
            set
            {
                this.weightEachField = value;
            }
        }

        /// <remarks/>
        public decimal Weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }

        /// <remarks/>
        public decimal BusinessVolumeEach
        {
            get
            {
                return this.businessVolumeEachField;
            }
            set
            {
                this.businessVolumeEachField = value;
            }
        }

        /// <remarks/>
        public decimal BusinesVolume
        {
            get
            {
                return this.businesVolumeField;
            }
            set
            {
                this.businesVolumeField = value;
            }
        }

        /// <remarks/>
        public decimal CommissionableVolumeEach
        {
            get
            {
                return this.commissionableVolumeEachField;
            }
            set
            {
                this.commissionableVolumeEachField = value;
            }
        }

        /// <remarks/>
        public decimal CommissionableVolume
        {
            get
            {
                return this.commissionableVolumeField;
            }
            set
            {
                this.commissionableVolumeField = value;
            }
        }

        /// <remarks/>
        public decimal Other1Each
        {
            get
            {
                return this.other1EachField;
            }
            set
            {
                this.other1EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other1
        {
            get
            {
                return this.other1Field;
            }
            set
            {
                this.other1Field = value;
            }
        }

        /// <remarks/>
        public decimal Other2Each
        {
            get
            {
                return this.other2EachField;
            }
            set
            {
                this.other2EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other2
        {
            get
            {
                return this.other2Field;
            }
            set
            {
                this.other2Field = value;
            }
        }

        /// <remarks/>
        public decimal Other3Each
        {
            get
            {
                return this.other3EachField;
            }
            set
            {
                this.other3EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other3
        {
            get
            {
                return this.other3Field;
            }
            set
            {
                this.other3Field = value;
            }
        }

        /// <remarks/>
        public decimal Other4Each
        {
            get
            {
                return this.other4EachField;
            }
            set
            {
                this.other4EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other4
        {
            get
            {
                return this.other4Field;
            }
            set
            {
                this.other4Field = value;
            }
        }

        /// <remarks/>
        public decimal Other5Each
        {
            get
            {
                return this.other5EachField;
            }
            set
            {
                this.other5EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other5
        {
            get
            {
                return this.other5Field;
            }
            set
            {
                this.other5Field = value;
            }
        }

        /// <remarks/>
        public decimal Other6Each
        {
            get
            {
                return this.other6EachField;
            }
            set
            {
                this.other6EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other6
        {
            get
            {
                return this.other6Field;
            }
            set
            {
                this.other6Field = value;
            }
        }

        /// <remarks/>
        public decimal Other7Each
        {
            get
            {
                return this.other7EachField;
            }
            set
            {
                this.other7EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other7
        {
            get
            {
                return this.other7Field;
            }
            set
            {
                this.other7Field = value;
            }
        }

        /// <remarks/>
        public decimal Other8Each
        {
            get
            {
                return this.other8EachField;
            }
            set
            {
                this.other8EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other8
        {
            get
            {
                return this.other8Field;
            }
            set
            {
                this.other8Field = value;
            }
        }

        /// <remarks/>
        public decimal Other9Each
        {
            get
            {
                return this.other9EachField;
            }
            set
            {
                this.other9EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other9
        {
            get
            {
                return this.other9Field;
            }
            set
            {
                this.other9Field = value;
            }
        }

        /// <remarks/>
        public decimal Other10Each
        {
            get
            {
                return this.other10EachField;
            }
            set
            {
                this.other10EachField = value;
            }
        }

        /// <remarks/>
        public decimal Other10
        {
            get
            {
                return this.other10Field;
            }
            set
            {
                this.other10Field = value;
            }
        }

        /// <remarks/>
        public string ParentItemCode
        {
            get
            {
                return this.parentItemCodeField;
            }
            set
            {
                this.parentItemCodeField = value;
            }
        }

        /// <remarks/>
        public decimal Taxable
        {
            get
            {
                return this.taxableField;
            }
            set
            {
                this.taxableField = value;
            }
        }

        /// <remarks/>
        public decimal FedTax
        {
            get
            {
                return this.fedTaxField;
            }
            set
            {
                this.fedTaxField = value;
            }
        }

        /// <remarks/>
        public decimal StateTax
        {
            get
            {
                return this.stateTaxField;
            }
            set
            {
                this.stateTaxField = value;
            }
        }

        /// <remarks/>
        public decimal CityTax
        {
            get
            {
                return this.cityTaxField;
            }
            set
            {
                this.cityTaxField = value;
            }
        }

        /// <remarks/>
        public decimal CityLocalTax
        {
            get
            {
                return this.cityLocalTaxField;
            }
            set
            {
                this.cityLocalTaxField = value;
            }
        }

        /// <remarks/>
        public decimal CountyTax
        {
            get
            {
                return this.countyTaxField;
            }
            set
            {
                this.countyTaxField = value;
            }
        }

        /// <remarks/>
        public decimal CountyLocalTax
        {
            get
            {
                return this.countyLocalTaxField;
            }
            set
            {
                this.countyLocalTaxField = value;
            }
        }

        /// <remarks/>
        public decimal ManualTax
        {
            get
            {
                return this.manualTaxField;
            }
            set
            {
                this.manualTaxField = value;
            }
        }

        /// <remarks/>
        public bool IsStateTaxOverride
        {
            get
            {
                return this.isStateTaxOverrideField;
            }
            set
            {
                this.isStateTaxOverrideField = value;
            }
        }

        /// <remarks/>
        public int OrderLine
        {
            get
            {
                return this.orderLineField;
            }
            set
            {
                this.orderLineField = value;
            }
        }

        /// <remarks/>
        public string Reference1
        {
            get
            {
                return this.reference1Field;
            }
            set
            {
                this.reference1Field = value;
            }
        }

        /// <remarks/>
        public decimal ShippingPriceEach
        {
            get
            {
                return this.shippingPriceEachField;
            }
            set
            {
                this.shippingPriceEachField = value;
            }
        }


    }

    public class ShipMethodEntity
    {
        public int ShipMethodID { get; set; }
        public string ShipMethodDescription { get; set; }
        public decimal Price { get; set; }
        public bool Selected { get; set; }
    }

}
