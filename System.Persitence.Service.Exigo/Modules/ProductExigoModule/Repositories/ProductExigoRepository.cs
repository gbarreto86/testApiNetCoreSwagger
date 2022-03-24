using ExigoWebService;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Domain.Entities.Exigo;
using System.Domain.Interfaces.Exigo;
using System.Infrastructure.Tools.Configuration;
using System.Linq;
using System.Persitence.Service.Exigo.Services;
using System.Threading.Tasks;

namespace System.Persitence.Service.Exigo.Repositories
{
    public class ProductExigoRepository : IProductExigoRepository
    {
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConnectionExigo _connectionExigo;

        public ProductExigoRepository(IOptions<AppSettings> appSettings,
                                   IConnectionExigo ConnectionExigo)
        {
            this.appSettings = appSettings;
            _connectionExigo = ConnectionExigo;
        }

        public Task<OrderCalculationResponseEntity> GetCalculateOrder(CalculateOrderRequestEntity objParametros)
        {           

            try
            {
                CalculateOrderRequest getOrder = new CalculateOrderRequest();

                OrderCalculationResponseEntity result = new OrderCalculationResponseEntity();                
                OrderDetailRequest[] listaOrderDetailRequest = new OrderDetailRequest[objParametros.ListOrderDetail.Length];
                List<OrderDetailResponseEntity> objDetailReponse = new List<OrderDetailResponseEntity>();


                getOrder.CustomerID = objParametros.CustomerID;
                getOrder.ShippingAmountOverride = objParametros.ShippingAmountOverride;
                getOrder.WarehouseID = objParametros.WarehouseID;
                getOrder.CurrencyCode = objParametros.CurrencyCode;
                getOrder.PriceType = objParametros.PriceType;
                getOrder.ShipMethodID = objParametros.ShipMethodID;
                getOrder.ReturnShipMethods = objParametros.ReturnShipMethods;

                getOrder.City = objParametros.City;
                getOrder.State = objParametros.State;
                getOrder.Address2 = objParametros.Address2;

                getOrder.Zip = objParametros.Zip;
                getOrder.Country = objParametros.Country;

                getOrder.PartyID = objParametros.PartyID;

                int index = 0;
                foreach (var item in objParametros.ListOrderDetail)
                {
                    listaOrderDetailRequest[index++] = new OrderDetailRequest
                    {
                        ItemCode = item.ItemCode,
                        Quantity = item.Quantity
                    };
                }

                getOrder.Details = listaOrderDetailRequest;

                var reponse = ExigoService.CalculateOrderAsync(getOrder);

                CalculateOrderResponse apiresponse = reponse.CalculateOrderResult;

                var discountItem = apiresponse.Details.Where(od => od.ItemCode == "DSCTPC" || od.ItemCode == "DSCTPC15" || od.ItemCode == "DSCT").FirstOrDefault();
                var discount = (discountItem != null) ? discountItem.PriceTotal : 0;

                result.Subtotal = apiresponse.SubTotal;
                result.Shipping = apiresponse.ShippingTotal;
                result.Tax = apiresponse.TaxTotal;
                //result.Discount = apiresponse.DiscountTotal;
                result.Discount = discount;
                result.BV = apiresponse.BusinessVolumeTotal;
                result.CV = apiresponse.CommissionableVolumeTotal;
                result.FedTaxTotal = apiresponse.FedTaxTotal;
                result.StateTaxTotal = apiresponse.StateTaxTotal;
                //result.Details = apiresponse.Details;
                result.DiscountFromExigo = apiresponse.DiscountTotal;
                result.Total = apiresponse.Total;

                result.Details = apiresponse.Details.Select(g => new OrderDetailResponseEntity()
                {
                    BusinessVolumeEach = g.BusinessVolumeEach,
                    BusinesVolume = g.BusinesVolume,
                    CityLocalTax = g.CityLocalTax,
                    CityTax = g.CityTax,
                    CommissionableVolume = g.CommissionableVolume,
                    CommissionableVolumeEach = g.CommissionableVolumeEach,
                    CountyLocalTax = g.CountyLocalTax,
                    CountyTax = g.CountyTax,
                    Description = g.Description,
                    FedTax = g.FedTax,
                    IsStateTaxOverride = g.IsStateTaxOverride,
                    ItemCode = g.ItemCode,
                    ManualTax = g.ManualTax,
                    OrderLine = g.OrderLine,
                    Other1 = g.Other1,
                    Other10 = g.Other10,
                    Other10Each = g.Other10Each,
                    Other1Each = g.Other1Each,
                    Other2 = g.Other2,
                    Other2Each = g.Other2Each,
                    Other3 = g.Other3,
                    Other3Each = g.Other3Each,
                    Other4 = g.Other4,
                    Other4Each = g.Other4Each,
                    Other5 = g.Other5,
                    Other5Each = g.Other5Each,
                    Other6 = g.Other6,
                    Other6Each = g.Other6Each,
                    Other7 = g.Other7,
                    Other7Each = g.Other7Each,
                    Other8 = g.Other8,
                    Other8Each = g.Other8Each,
                    Other9 = g.Other9,
                    Other9Each = g.Other9Each,
                    ParentItemCode = g.ParentItemCode,
                    PriceEach = g.PriceEach,
                    PriceTotal = g.PriceTotal,
                    Quantity = g.Quantity,
                    Reference1 = g.Reference1,
                    ShippingPriceEach = g.ShippingPriceEach,
                    StateTax = g.StateTax,
                    Tax = g.Tax,
                    Taxable = g.Taxable,
                    Weight = g.Weight,
                    WeightEach = g.WeightEach
                }).AsEnumerable();

                var shipMethods = new List<ShipMethodEntity>();
                if (apiresponse.ShipMethods != null && apiresponse.ShipMethods.Length > 0)
                {
                    foreach (var shipMethod in apiresponse.ShipMethods)
                    {
                        if (objParametros.ShippingAmountOverride == 0)
                        {
                            shipMethod.ShippingAmount = 0;
                        }

                        shipMethods.Add(new ShipMethodEntity
                        {
                            ShipMethodDescription = shipMethod.Description,
                            ShipMethodID = shipMethod.ShipMethodID,
                            Price = shipMethod.ShippingAmount
                        });
                    }
                   
                    var shipMethodID = objParametros.ShipMethodID;
                    if (shipMethods.Any(c => c.ShipMethodID == (int)shipMethodID))
                    {
                        shipMethods.First(c => c.ShipMethodID == shipMethodID).Selected = true;
                    }
                    else
                    {
                        shipMethods.First().Selected = true;
                    }
                }
                result.ShipMethods = shipMethods.AsEnumerable();

                return Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
