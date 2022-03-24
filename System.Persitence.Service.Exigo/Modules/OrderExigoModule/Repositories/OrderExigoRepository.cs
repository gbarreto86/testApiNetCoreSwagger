using ExigoWebService;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Domain.Entities.Exigo;
using System.Domain.Entities.Exigo.OrderExigoModule;
using System.Domain.Interfaces.Exigo;
using System.Infrastructure.Tools.Configuration;
using System.Persitence.Service.Exigo.Services;
using System.Threading.Tasks;

namespace System.Persitence.Service.Exigo.Repositories
{
    public class OrderExigoRepository: IOrderExigoRepository
    {
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConnectionExigo _connectionExigo;
        public OrderExigoRepository(IOptions<AppSettings> appSettings,
                                   IConnectionExigo ConnectionExigo)
        {
            this.appSettings = appSettings;
            _connectionExigo = ConnectionExigo;
        }
        public Task<TransactionalResponseEntity> ProcessTransaction(TransactionalRequestEntity objParametros)
        {
            List<ApiRequest> details = new List<ApiRequest>();

            #region CreateCustomerRequest
            if (objParametros.CreateCustomerRequest != null)
            {
                CreateCustomerRequest custReq = new CreateCustomerRequest()
                {
                    FirstName = objParametros.CreateCustomerRequest.FirstName,
                    Company = objParametros.CreateCustomerRequest.Company,
                    LastName = objParametros.CreateCustomerRequest.LastName,
                    CustomerType = objParametros.CreateCustomerRequest.CustomerType,
                    CustomerStatus = objParametros.CreateCustomerRequest.CustomerStatus,
                    Email = objParametros.CreateCustomerRequest.Email,
                    Phone = objParametros.CreateCustomerRequest.Phone,
                    Phone2 = objParametros.CreateCustomerRequest.Phone2,
                    MobilePhone = objParametros.CreateCustomerRequest.MobilePhone,
                    Fax = objParametros.CreateCustomerRequest.Fax,
                    Notes = objParametros.CreateCustomerRequest.Notes,
                    MainAddress1 = objParametros.CreateCustomerRequest.MainAddress1,
                    MainAddress2 = objParametros.CreateCustomerRequest.MainAddress2,
                    MainAddress3 = objParametros.CreateCustomerRequest.MainAddress3,
                    MainCity = objParametros.CreateCustomerRequest.MainCity,
                    MainState = objParametros.CreateCustomerRequest.MainState,
                    MainZip = objParametros.CreateCustomerRequest.MainZip,
                    MainCountry = objParametros.CreateCustomerRequest.MainCountry,
                    MainCounty = objParametros.CreateCustomerRequest.MainCounty,
                    MailAddress1 = objParametros.CreateCustomerRequest.MailAddress1,
                    MailAddress2 = objParametros.CreateCustomerRequest.MailAddress2,
                    MailAddress3 = objParametros.CreateCustomerRequest.MailAddress3,
                    MailCity = objParametros.CreateCustomerRequest.MailCity,
                    MailState = objParametros.CreateCustomerRequest.MailState,
                    MailZip = objParametros.CreateCustomerRequest.MailZip,
                    MailCountry = objParametros.CreateCustomerRequest.MailCountry,
                    MailCounty = objParametros.CreateCustomerRequest.MailCounty,
                    OtherAddress1 = objParametros.CreateCustomerRequest.OtherAddress1,
                    OtherAddress2 = objParametros.CreateCustomerRequest.OtherAddress2,
                    OtherAddress3 = objParametros.CreateCustomerRequest.OtherAddress3,
                    OtherCity = objParametros.CreateCustomerRequest.OtherCity,
                    OtherState = objParametros.CreateCustomerRequest.OtherState,
                    OtherZip = objParametros.CreateCustomerRequest.OtherZip,
                    OtherCountry = objParametros.CreateCustomerRequest.OtherCountry,
                    OtherCounty = objParametros.CreateCustomerRequest.OtherCounty,
                    CanLogin = objParametros.CreateCustomerRequest.CanLogin,
                    LoginName = objParametros.CreateCustomerRequest.LoginName,
                    LoginPassword = objParametros.CreateCustomerRequest.LoginPassword,
                    InsertEnrollerTree = objParametros.CreateCustomerRequest.InsertEnrollerTree,
                    EnrollerID = objParametros.CreateCustomerRequest.EnrollerID,
                    InsertUnilevelTree = objParametros.CreateCustomerRequest.InsertUnilevelTree,
                    SponsorID = objParametros.CreateCustomerRequest.SponsorID,
                    UseManualCustomerID = objParametros.CreateCustomerRequest.UseManualCustomerID,
                    ManualCustomerID = objParametros.CreateCustomerRequest.ManualCustomerID,
                    TaxID = objParametros.CreateCustomerRequest.TaxID,
                    SalesTaxID = objParametros.CreateCustomerRequest.SalesTaxID,
                    SalesTaxExemptExpireDate = objParametros.CreateCustomerRequest.SalesTaxExemptExpireDate,
                    IsSalesTaxExempt = objParametros.CreateCustomerRequest.IsSalesTaxExempt,
                    BirthDate = objParametros.CreateCustomerRequest.BirthDate,
                    Field1 = objParametros.CreateCustomerRequest.Field1,
                    Field2 = objParametros.CreateCustomerRequest.Field2,
                    Field3 = objParametros.CreateCustomerRequest.Field3,
                    Field4 = objParametros.CreateCustomerRequest.Field4,
                    Field5 = objParametros.CreateCustomerRequest.Field5,
                    Field6 = objParametros.CreateCustomerRequest.Field6,
                    Field7 = objParametros.CreateCustomerRequest.Field7,
                    Field8 = objParametros.CreateCustomerRequest.Field8,
                    Field9 = objParametros.CreateCustomerRequest.Field9,
                    Field10 = objParametros.CreateCustomerRequest.Field10,
                    Field11 = objParametros.CreateCustomerRequest.Field11,
                    Field12 = objParametros.CreateCustomerRequest.Field12,
                    Field13 = objParametros.CreateCustomerRequest.Field13,
                    Field14 = objParametros.CreateCustomerRequest.Field14,
                    Field15 = objParametros.CreateCustomerRequest.Field15,
                    SubscribeToBroadcasts = objParametros.CreateCustomerRequest.SubscribeToBroadcasts,
                    SubscribeFromIPAddress = objParametros.CreateCustomerRequest.SubscribeFromIPAddress,
                    CurrencyCode = objParametros.CreateCustomerRequest.CurrencyCode,
                    PayableToName = objParametros.CreateCustomerRequest.PayableToName,
                    EntryDate = objParametros.CreateCustomerRequest.EntryDate,
                    DefaultWarehouseID = objParametros.CreateCustomerRequest.DefaultWarehouseID,
                    PayableType = (ExigoWebService.PayableType)((int)objParametros.CreateCustomerRequest.PayableType),
                    CheckThreshold = objParametros.CreateCustomerRequest.CheckThreshold,
                    TaxIDType = objParametros.CreateCustomerRequest.TaxIDType,
                    LanguageID = objParametros.CreateCustomerRequest.LanguageID,
                    Gender = (ExigoWebService.Gender)((int)objParametros.CreateCustomerRequest.Gender),
                    VatRegistration = objParametros.CreateCustomerRequest.VatRegistration,
                    Date1 = objParametros.CreateCustomerRequest.Date1,
                    Date2 = objParametros.CreateCustomerRequest.Date2,
                    Date3 = objParametros.CreateCustomerRequest.Date3,
                    Date4 = objParametros.CreateCustomerRequest.Date4,
                    Date5 = objParametros.CreateCustomerRequest.Date5,
                    MiddleName = objParametros.CreateCustomerRequest.MiddleName,
                    NameSuffix = objParametros.CreateCustomerRequest.NameSuffix,
                    BinaryPlacementPreference = objParametros.CreateCustomerRequest.BinaryPlacementPreference,
                    UseBinaryHoldingTank = objParametros.CreateCustomerRequest.UseBinaryHoldingTank,
                    MainAddressVerified = objParametros.CreateCustomerRequest.MainAddressVerified,
                    MailAddressVerified = objParametros.CreateCustomerRequest.MailAddressVerified,
                    OtherAddressVerified = objParametros.CreateCustomerRequest.OtherAddressVerified,
                    SponsorKey = objParametros.CreateCustomerRequest.SponsorKey,
                    EnrollerKey = objParametros.CreateCustomerRequest.EnrollerKey,
                    ManualCustomerKey = objParametros.CreateCustomerRequest.ManualCustomerKey
                };

                details.Add(custReq);
            }
            #endregion

            #region CreateOrderRequest
            if (objParametros.CreateOrderRequest != null)
            {
                CreateOrderRequest ordReq = new CreateOrderRequest()
                {
                    CustomerID = objParametros.CreateOrderRequest.CustomerID,
                    OrderStatus = (ExigoWebService.OrderStatusType)((int)objParametros.CreateOrderRequest.OrderStatus),
                    OrderDate = objParametros.CreateOrderRequest.OrderDate,
                    CurrencyCode = objParametros.CreateOrderRequest.CurrencyCode,
                    WarehouseID = objParametros.CreateOrderRequest.WarehouseID,
                    ShipMethodID = objParametros.CreateOrderRequest.ShipMethodID,
                    PriceType = objParametros.CreateOrderRequest.PriceType,
                    FirstName = objParametros.CreateOrderRequest.FirstName,
                    MiddleName = objParametros.CreateOrderRequest.MiddleName,
                    LastName = objParametros.CreateOrderRequest.LastName,
                    NameSuffix = objParametros.CreateOrderRequest.NameSuffix,
                    Company = objParametros.CreateOrderRequest.Company,
                    Address1 = objParametros.CreateOrderRequest.Address1,
                    Address2 = objParametros.CreateOrderRequest.Address2,
                    Address3 = objParametros.CreateOrderRequest.Address3,
                    City = objParametros.CreateOrderRequest.City,
                    State = objParametros.CreateOrderRequest.State,
                    Zip = objParametros.CreateOrderRequest.Zip,
                    Country = objParametros.CreateOrderRequest.Country,
                    County = objParametros.CreateOrderRequest.County,
                    Email = objParametros.CreateOrderRequest.Email,
                    Phone = objParametros.CreateOrderRequest.Phone,
                    Notes = objParametros.CreateOrderRequest.Notes,
                    Other11 = objParametros.CreateOrderRequest.Other11,
                    Other12 = objParametros.CreateOrderRequest.Other12,
                    Other13 = objParametros.CreateOrderRequest.Other13,
                    Other14 = objParametros.CreateOrderRequest.Other14,
                    Other15 = objParametros.CreateOrderRequest.Other15,
                    Other16 = objParametros.CreateOrderRequest.Other16,
                    Other17 = objParametros.CreateOrderRequest.Other17,
                    Other18 = objParametros.CreateOrderRequest.Other18,
                    Other19 = objParametros.CreateOrderRequest.Other19,
                    Other20 = objParametros.CreateOrderRequest.Other20,
                    OrderType = (ExigoWebService.OrderType)((int)objParametros.CreateOrderRequest.OrderType),
                    TaxRateOverride = objParametros.CreateOrderRequest.TaxRateOverride,
                    ShippingAmountOverride = objParametros.CreateOrderRequest.ShippingAmountOverride,
                    UseManualOrderID = objParametros.CreateOrderRequest.UseManualOrderID,
                    ManualOrderID = objParametros.CreateOrderRequest.ManualOrderID,
                    TransferVolumeToID = objParametros.CreateOrderRequest.TransferVolumeToID,
                    ReturnOrderID = objParametros.CreateOrderRequest.ReturnOrderID,
                    OverwriteExistingOrder = objParametros.CreateOrderRequest.OverwriteExistingOrder,
                    ExistingOrderID = objParametros.CreateOrderRequest.ExistingOrderID,
                    PartyID = objParametros.CreateOrderRequest.PartyID,
                    SuppressPackSlipPrice = objParametros.CreateOrderRequest.SuppressPackSlipPrice,
                    TransferVolumeToKey = objParametros.CreateOrderRequest.TransferVolumeToKey,
                    ReturnOrderKey = objParametros.CreateOrderRequest.ReturnOrderKey,
                    ManualOrderKey = objParametros.CreateOrderRequest.ManualOrderKey,
                    ExistingOrderKey = objParametros.CreateOrderRequest.ExistingOrderKey,
                    CustomerKey = objParametros.CreateOrderRequest.CustomerKey,
                };
                
                List<OrderDetailRequest> OrderDetailRequest = new List<OrderDetailRequest>();
                foreach (OrderDetailRequestEntity detail in objParametros.CreateOrderRequest.Details)
                {

                    OrderDetailRequest DetailsEach = new OrderDetailRequest()
                    {
                        ItemCode = detail.ItemCode,
                        OrderDetailID = detail.OrderDetailID,
                        ParentOrderDetailID = detail.ParentOrderDetailID,
                        Quantity = detail.Quantity,
                        ParentItemCode = detail.ParentItemCode,
                        PriceEachOverride = detail.PriceEachOverride,
                        TaxableEachOverride = detail.TaxableEachOverride,
                        ShippingPriceEachOverride = detail.ShippingPriceEachOverride,
                        BusinessVolumeEachOverride = detail.BusinessVolumeEachOverride,
                        CommissionableVolumeEachOverride = detail.CommissionableVolumeEachOverride,
                        Other1EachOverride = detail.Other1EachOverride,
                        Other2EachOverride = detail.Other2EachOverride,
                        Other3EachOverride = detail.Other3EachOverride,
                        Other4EachOverride = detail.Other4EachOverride,
                        Other5EachOverride = detail.Other5EachOverride,
                        Other6EachOverride = detail.Other6EachOverride,
                        Other7EachOverride = detail.Other7EachOverride,
                        Other8EachOverride = detail.Other8EachOverride,
                        Other9EachOverride = detail.Other9EachOverride,
                        Other10EachOverride = detail.Other10EachOverride,
                        DescriptionOverride = detail.DescriptionOverride,
                        Reference1 = detail.Reference1
                    };

                    if (detail.AdvancedAutoOptions!=null) {
                        DetailsEach.AdvancedAutoOptions = new AdvancedAutoOptionsRequest()
                        {
                            ProcessWhileDate = detail.AdvancedAutoOptions.ProcessWhileDate,
                            SkipUntilDate = detail.AdvancedAutoOptions.SkipUntilDate,
                            DetailStartDate = detail.AdvancedAutoOptions.DetailStartDate,
                            DetailEndDate = detail.AdvancedAutoOptions.DetailEndDate,
                            DetailInterval = detail.AdvancedAutoOptions.DetailInterval
                        };
                    }

                    OrderDetailRequest.Add(DetailsEach);
                }
                ordReq.Details = OrderDetailRequest.ToArray();

                details.Add(ordReq);
            }
            #endregion

            #region CreatePaymentCreditCardRequest
            if (objParametros.CreatePaymentCreditCardRequest != null)
            {
                CreatePaymentCreditCardRequest payReq = new CreatePaymentCreditCardRequest()
                {
                    OrderID = objParametros.CreatePaymentCreditCardRequest.OrderID,
                    PaymentDate = objParametros.CreatePaymentCreditCardRequest.PaymentDate,
                    Amount = objParametros.CreatePaymentCreditCardRequest.Amount,
                    CreditCardNumber = objParametros.CreatePaymentCreditCardRequest.CreditCardNumber,
                    ExpirationMonth = objParametros.CreatePaymentCreditCardRequest.ExpirationMonth,
                    ExpirationYear = objParametros.CreatePaymentCreditCardRequest.ExpirationYear,
                    BillingName = objParametros.CreatePaymentCreditCardRequest.BillingName,
                    BillingAddress = objParametros.CreatePaymentCreditCardRequest.BillingAddress,
                    BillingAddress2 = objParametros.CreatePaymentCreditCardRequest.BillingAddress2,
                    BillingCity = objParametros.CreatePaymentCreditCardRequest.BillingCity,
                    BillingState = objParametros.CreatePaymentCreditCardRequest.BillingState,
                    BillingZip = objParametros.CreatePaymentCreditCardRequest.BillingZip,
                    BillingCountry = objParametros.CreatePaymentCreditCardRequest.BillingCountry,
                    CreditCardType = objParametros.CreatePaymentCreditCardRequest.CreditCardType,
                    AuthorizationCode = objParametros.CreatePaymentCreditCardRequest.AuthorizationCode,
                    Memo = objParametros.CreatePaymentCreditCardRequest.Memo,
                    OrderKey = objParametros.CreatePaymentCreditCardRequest.OrderKey,
                    MerchantTransactionKey = objParametros.CreatePaymentCreditCardRequest.MerchantTransactionKey
                };

                details.Add(payReq);
            }
            #endregion

            #region CreateAutoOrderRequest
            if (objParametros.CreateAutoOrderRequest != null)
            {
                CreateAutoOrderRequest aoReq = new CreateAutoOrderRequest()
                {
                    CustomerID = objParametros.CreateAutoOrderRequest.CustomerID,
                    Frequency = (ExigoWebService.FrequencyType)((int)objParametros.CreateAutoOrderRequest.Frequency),
                    StartDate = objParametros.CreateAutoOrderRequest.StartDate,
                    StopDate = objParametros.CreateAutoOrderRequest.StopDate,
                    SpecificDayInterval = objParametros.CreateAutoOrderRequest.SpecificDayInterval,
                    CurrencyCode = objParametros.CreateAutoOrderRequest.CurrencyCode,
                    WarehouseID = objParametros.CreateAutoOrderRequest.WarehouseID,
                    ShipMethodID = objParametros.CreateAutoOrderRequest.ShipMethodID,
                    PriceType = objParametros.CreateAutoOrderRequest.PriceType,
                    PaymentType = (ExigoWebService.AutoOrderPaymentType)((int)objParametros.CreateAutoOrderRequest.PaymentType),
                    ProcessType = (ExigoWebService.AutoOrderProcessType)((int)objParametros.CreateAutoOrderRequest.ProcessType),
                    FirstName = objParametros.CreateAutoOrderRequest.FirstName,
                    MiddleName = objParametros.CreateAutoOrderRequest.MiddleName,
                    LastName = objParametros.CreateAutoOrderRequest.LastName,
                    NameSuffix = objParametros.CreateAutoOrderRequest.NameSuffix,
                    Company = objParametros.CreateAutoOrderRequest.Company,
                    Address1 = objParametros.CreateAutoOrderRequest.Address1,
                    Address2 = objParametros.CreateAutoOrderRequest.Address2,
                    Address3 = objParametros.CreateAutoOrderRequest.Address3,
                    City = objParametros.CreateAutoOrderRequest.City,
                    State = objParametros.CreateAutoOrderRequest.State,
                    Zip = objParametros.CreateAutoOrderRequest.Zip,
                    Country = objParametros.CreateAutoOrderRequest.Country,
                    County = objParametros.CreateAutoOrderRequest.County,
                    Email = objParametros.CreateAutoOrderRequest.Email,
                    Phone = objParametros.CreateAutoOrderRequest.Phone,
                    Notes = objParametros.CreateAutoOrderRequest.Notes,
                    Other11 = objParametros.CreateAutoOrderRequest.Other11,
                    Other12 = objParametros.CreateAutoOrderRequest.Other12,
                    Other13 = objParametros.CreateAutoOrderRequest.Other13,
                    Other14 = objParametros.CreateAutoOrderRequest.Other14,
                    Other15 = objParametros.CreateAutoOrderRequest.Other15,
                    Other16 = objParametros.CreateAutoOrderRequest.Other16,
                    Other17 = objParametros.CreateAutoOrderRequest.Other17,
                    Other18 = objParametros.CreateAutoOrderRequest.Other18,
                    Other19 = objParametros.CreateAutoOrderRequest.Other19,
                    Other20 = objParametros.CreateAutoOrderRequest.Other20,
                    Description = objParametros.CreateAutoOrderRequest.Description,
                    OverwriteExistingAutoOrder = objParametros.CreateAutoOrderRequest.OverwriteExistingAutoOrder,
                    ExistingAutoOrderID = objParametros.CreateAutoOrderRequest.ExistingAutoOrderID,
                    CustomerKey = objParametros.CreateAutoOrderRequest.CustomerKey
                };

                List<OrderDetailRequest> AutoOrderDetailRequest = new List<OrderDetailRequest>();
                foreach (OrderDetailRequestEntity detail in objParametros.CreateAutoOrderRequest.Details)
                {
                    OrderDetailRequest DetailsEach = new OrderDetailRequest()
                    {
                        ItemCode = detail.ItemCode,
                        OrderDetailID = detail.OrderDetailID,
                        ParentOrderDetailID = detail.ParentOrderDetailID,
                        Quantity = detail.Quantity,
                        ParentItemCode = detail.ParentItemCode,
                        PriceEachOverride = detail.PriceEachOverride,
                        TaxableEachOverride = detail.TaxableEachOverride,
                        ShippingPriceEachOverride = detail.ShippingPriceEachOverride,
                        BusinessVolumeEachOverride = detail.BusinessVolumeEachOverride,
                        CommissionableVolumeEachOverride = detail.CommissionableVolumeEachOverride,
                        Other1EachOverride = detail.Other1EachOverride,
                        Other2EachOverride = detail.Other2EachOverride,
                        Other3EachOverride = detail.Other3EachOverride,
                        Other4EachOverride = detail.Other4EachOverride,
                        Other5EachOverride = detail.Other5EachOverride,
                        Other6EachOverride = detail.Other6EachOverride,
                        Other7EachOverride = detail.Other7EachOverride,
                        Other8EachOverride = detail.Other8EachOverride,
                        Other9EachOverride = detail.Other9EachOverride,
                        Other10EachOverride = detail.Other10EachOverride,
                        DescriptionOverride = detail.DescriptionOverride,
                        Reference1 = detail.Reference1                        
                    };

                    if (detail.AdvancedAutoOptions!=null) {
                        DetailsEach.AdvancedAutoOptions = new AdvancedAutoOptionsRequest()
                        {
                            ProcessWhileDate = detail.AdvancedAutoOptions.ProcessWhileDate,
                            SkipUntilDate = detail.AdvancedAutoOptions.SkipUntilDate,
                            DetailStartDate = detail.AdvancedAutoOptions.DetailStartDate,
                            DetailEndDate = detail.AdvancedAutoOptions.DetailEndDate,
                            DetailInterval = detail.AdvancedAutoOptions.DetailInterval
                        };
                    }

                    AutoOrderDetailRequest.Add(DetailsEach);
                }

                aoReq.Details = AutoOrderDetailRequest.ToArray();

                details.Add(aoReq);
            }
            #endregion

            #region SetAccountCreditCardRequest
            if (objParametros.SetAccountCreditCardRequest != null)
            {
                SetAccountCreditCardRequest saccReq = new SetAccountCreditCardRequest()
                {
                    CustomerID = objParametros.SetAccountCreditCardRequest.CustomerID,
                    CreditCardAccountType = (ExigoWebService.AccountCreditCardType)((int)objParametros.SetAccountCreditCardRequest.CreditCardAccountType),
                    CreditCardNumber = objParametros.SetAccountCreditCardRequest.CreditCardNumber,
                    ExpirationMonth = objParametros.SetAccountCreditCardRequest.ExpirationMonth,
                    ExpirationYear = objParametros.SetAccountCreditCardRequest.ExpirationYear,
                    CvcCode = objParametros.SetAccountCreditCardRequest.CvcCode,
                    IssueCode = objParametros.SetAccountCreditCardRequest.IssueCode,
                    CreditCardType = objParametros.SetAccountCreditCardRequest.CreditCardType,
                    BillingName = objParametros.SetAccountCreditCardRequest.BillingName,
                    UseMainAddress = objParametros.SetAccountCreditCardRequest.UseMainAddress,
                    BillingAddress = objParametros.SetAccountCreditCardRequest.BillingAddress,
                    BillingCity = objParametros.SetAccountCreditCardRequest.BillingCity,
                    BillingState = objParametros.SetAccountCreditCardRequest.BillingState,
                    BillingZip = objParametros.SetAccountCreditCardRequest.BillingZip,
                    BillingCountry = objParametros.SetAccountCreditCardRequest.BillingCountry,
                    HideFromWeb = objParametros.SetAccountCreditCardRequest.HideFromWeb,
                    CustomerKey = objParametros.SetAccountCreditCardRequest.CustomerKey,
                };

                details.Add(saccReq);
            }
            #endregion

            #region ChargeCreditCardTokenRequest      
            if (objParametros.ChargeCreditCardTokenRequest != null)
            {
                ChargeCreditCardTokenRequest cctReq = new ChargeCreditCardTokenRequest()
                {
                    CreditCardToken = objParametros.ChargeCreditCardTokenRequest.CreditCardToken,
                    BillingName = objParametros.ChargeCreditCardTokenRequest.BillingName,
                    BillingAddress = objParametros.ChargeCreditCardTokenRequest.BillingAddress,
                    BillingAddress2 = objParametros.ChargeCreditCardTokenRequest.BillingAddress2,
                    BillingCity = objParametros.ChargeCreditCardTokenRequest.BillingCity,
                    BillingState = objParametros.ChargeCreditCardTokenRequest.BillingState,
                    BillingZip = objParametros.ChargeCreditCardTokenRequest.BillingZip,
                    BillingCountry = objParametros.ChargeCreditCardTokenRequest.BillingCountry,
                    CvcCode = objParametros.ChargeCreditCardTokenRequest.CvcCode,
                    IssueNumber = objParametros.ChargeCreditCardTokenRequest.IssueNumber,
                    CreditCardType = objParametros.ChargeCreditCardTokenRequest.CreditCardType,
                    ExpirationMonth = objParametros.ChargeCreditCardTokenRequest.ExpirationMonth,
                    ExpirationYear = objParametros.ChargeCreditCardTokenRequest.ExpirationYear,
                    OrderID = objParametros.ChargeCreditCardTokenRequest.OrderID,
                    MaxAmount = objParametros.ChargeCreditCardTokenRequest.MaxAmount,
                    MerchantWarehouseIDOverride = objParametros.ChargeCreditCardTokenRequest.MerchantWarehouseIDOverride,
                    ClientIPAddress = objParametros.ChargeCreditCardTokenRequest.ClientIPAddress,
                    OtherData1 = objParametros.ChargeCreditCardTokenRequest.OtherData1,
                    OtherData2 = objParametros.ChargeCreditCardTokenRequest.OtherData2,
                    OtherData3 = objParametros.ChargeCreditCardTokenRequest.OtherData3,
                    OtherData4 = objParametros.ChargeCreditCardTokenRequest.OtherData4,
                    OtherData5 = objParametros.ChargeCreditCardTokenRequest.OtherData5,
                    OtherData6 = objParametros.ChargeCreditCardTokenRequest.OtherData6,
                    OtherData7 = objParametros.ChargeCreditCardTokenRequest.OtherData7,
                    OtherData8 = objParametros.ChargeCreditCardTokenRequest.OtherData8,
                    OtherData9 = objParametros.ChargeCreditCardTokenRequest.OtherData9,
                    OtherData10 = objParametros.ChargeCreditCardTokenRequest.OtherData10,
                    OrderKey = objParametros.ChargeCreditCardTokenRequest.OrderKey
                };

                details.Add(cctReq);
            }
            #endregion

            #region ChargeCreditCardTokenOnFileRequest      
            if (objParametros.ChargeCreditCardTokenOnFileRequest != null)
            {
                ChargeCreditCardTokenOnFileRequest cctofReq = new ChargeCreditCardTokenOnFileRequest()
                {
                    CreditCardAccountType = (ExigoWebService.AccountCreditCardType)((int)objParametros.ChargeCreditCardTokenOnFileRequest.CreditCardAccountType),
                    OrderID = objParametros.ChargeCreditCardTokenOnFileRequest.OrderID,
                    CvcCode = objParametros.ChargeCreditCardTokenOnFileRequest.CvcCode,
                    MaxAmount = objParametros.ChargeCreditCardTokenOnFileRequest.MaxAmount,
                    MerchantWarehouseIDOverride = objParametros.ChargeCreditCardTokenOnFileRequest.MerchantWarehouseIDOverride,
                    ClientIPAddress = objParametros.ChargeCreditCardTokenOnFileRequest.ClientIPAddress,
                    OtherData1 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData1,
                    OtherData2 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData2,
                    OtherData3 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData3,
                    OtherData4 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData4,
                    OtherData5 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData5,
                    OtherData6 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData6,
                    OtherData7 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData7,
                    OtherData8 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData8,
                    OtherData9 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData9,
                    OtherData10 = objParametros.ChargeCreditCardTokenOnFileRequest.OtherData10,
                    OrderKey = objParametros.ChargeCreditCardTokenOnFileRequest.OrderKey
                };

                details.Add(cctofReq);
            }

            #endregion

            #region proceso
            TransactionalRequest req = new TransactionalRequest();
            req.TransactionRequests = details.ToArray();
            ProcessTransactionResponse response = ExigoService.ProcessTransactionAsync(req);
            #endregion

            #region respuesta
            TransactionalResponseEntity result = new TransactionalResponseEntity()
            {
                Result = new ApiResultEntity() 
                {
                    Status= (Domain.Entities.Exigo.ResultStatus)((int)response.ProcessTransactionResult.Result.Status),
                    Errors= response.ProcessTransactionResult.Result.Errors,
                    TransactionKey= response.ProcessTransactionResult.Result.TransactionKey
                }
            };

            foreach (ApiResponse detail in response.ProcessTransactionResult.TransactionResponses) 
            {
                ApiResponseEntity DetailsEach = new ApiResponseEntity()
                {
                    Result = new ApiResultEntity()
                    {
                        Status = (Domain.Entities.Exigo.ResultStatus)((int)detail.Result.Status),
                        Errors = detail.Result.Errors,
                        TransactionKey = detail.Result.TransactionKey
                    }
                };

                result.TransactionResponses.Add(DetailsEach);
            }
            #endregion
            return Task.FromResult(result);
        }

        public Task<bool> UpdateOrder(UpdateOrderRequestEntity objParametros)
        {
            try
            {
                UpdateOrderRequest getRequest = new UpdateOrderRequest();

                getRequest.OrderID = objParametros.OrderId;
                getRequest.Other18 = objParametros.Other18;

                var a = ExigoService.UpdateOrder(getRequest);

                var prueba = a.UpdateOrderResult.Result;

                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<OrderResponseEntity> GetOrder(GetOrderRequestEntity objParametros)
        {
            try
            {
                GetOrdersRequest getRequest = new GetOrdersRequest();

                getRequest.OrderID = objParametros.OrderId;

                var a = ExigoService.GetOrders(getRequest);

                var response = a.GetOrdersResult.Orders;

                OrderResponseEntity result = new OrderResponseEntity();

                if(response.Length > 0)
                {
                    result.Total = response[0].Total;
                    result.OrderStatus = (int)response[0].OrderStatus;
                }


                return Task.FromResult(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CreatePayment(CreatePaymentRequestEntity objParametros)
        {
            try
            {
                CreatePaymentRequest getRequest = new CreatePaymentRequest();

                getRequest.OrderID = objParametros.OrderID;
                getRequest.Amount = objParametros.Amount;
                getRequest.BillingName = objParametros.BillingName;
                getRequest.PaymentDate = objParametros.PaymentDate;
                getRequest.PaymentType = (PaymentType)objParametros.PaymentType;
                getRequest.Memo = objParametros.Memo;

                var a = ExigoService.CreatePayment(getRequest);

                var prueba = a.CreatePaymentResult.Result;

                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
