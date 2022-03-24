using ExigoWebService;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Domain.Entities.Exigo;
using System.Domain.Entities.Exigo.CustomerExigoModule;
using System.Domain.Interfaces.Exigo;
using System.Infrastructure.Tools.Configuration;
using System.Linq;
using System.Net;
using System.Persitence.Service.Exigo.Services;
using System.Threading.Tasks;

namespace System.Persitence.Service.Exigo.Repositories
{
    public class CustomerExigoRepository : ICustomerExigoRepository
    {
        private readonly IOptions<AppSettings> appSettings;
        private readonly IConnectionExigo _connectionExigo;
        public CustomerExigoRepository(IOptions<AppSettings> appSettings,
                                   IConnectionExigo ConnectionExigo)
        {
            this.appSettings = appSettings;
            _connectionExigo = ConnectionExigo;
        }
        public Task<AuthenticateEntity> AuthenticateCustomer(AuthenticateRequestEntity objParametro)
        {
            try
            {
                AuthenticateCustomerRequest authenticateCustomerRequest = new AuthenticateCustomerRequest();

                authenticateCustomerRequest.LoginName = objParametro.LoginName;
                authenticateCustomerRequest.Password = objParametro.Password;

                var response = ExigoService.AuthenticateCustomerAsync(authenticateCustomerRequest);

                AuthenticateCustomerResponse obj = response.AuthenticateCustomerResult;

                AuthenticateEntity objResponse = new AuthenticateEntity
                {
                    CustomerID = obj.CustomerID,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName
                };


                return Task.FromResult(objResponse);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<CustomerExigoEntity> GetCustomer(CustomerExigoRequestEntity objParametro)
        {
            CustomerExigoEntity objResponse = null;

            try
            {
                GetCustomersRequest getCustomersRequest = new GetCustomersRequest();

                getCustomersRequest.CustomerID = objParametro.CustomerID;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var response = ExigoService.GetCustomersAsync(getCustomersRequest);

                if (response.GetCustomersResult.Customers != null && response.GetCustomersResult.Customers.Length > 0)
                {
                    CustomerResponse objCustomer = response.GetCustomersResult.Customers[0];
                    
                    objResponse = new CustomerExigoEntity
                    {
                        Company = objCustomer.Company,
                        CurrencyCode = objCustomer.CurrencyCode,
                        CustomerID = objCustomer.CustomerID,
                        CustomerStatusID = objCustomer.CustomerStatus,
                        CustomerTypeID = objCustomer.CustomerType,
                        DefaultWarehouseID = objCustomer.DefaultWarehouseID,
                        FirstName = objCustomer.FirstName,
                        LanguageID = objCustomer.LanguageID,
                        LastName = objCustomer.LastName,
                        LoginName = objCustomer.LoginName,
                        Email = objCustomer.Email,
                        MobilePhone = objCustomer.MobilePhone
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(objResponse);
        }

        public Task<string> GetCustomerWebAlias(CustomerExigoRequestEntity objParametro)
        {
            try
            {
                GetCustomerSiteRequest getCustomer = new GetCustomerSiteRequest();

                getCustomer.CustomerID = objParametro.CustomerID;

                var a = ExigoService.GetCustomerSiteAsync(getCustomer);

                return Task.FromResult(a.GetCustomerSiteResult.WebAlias);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> GetValidateAutoOrder(ValidateAutoOrderRequestEntity objParametro)
        {
            try
            {
                GetAutoOrdersRequest getCustomer = new GetAutoOrdersRequest();

                getCustomer.CustomerID = objParametro.CustomerID;

                if (!objParametro.IncludeCancelledAutoOrders) getCustomer.AutoOrderStatus = 0;

                var a = ExigoService.GetAutoOrdersAsync(getCustomer);

                var model = a.GetAutoOrdersResult.AutoOrders;

                return Task.FromResult((model != null));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  Task<bool> IsTaxIDAvailable(CustomerTaxAvailableRequestEntity objParametro)
        {
            try
            {
                objParametro.TaxID = objParametro.TaxID.Split('-').First();

                GetCustomReportRequest getRequest = new GetCustomReportRequest();

                getRequest.ReportID = 7;
                getRequest.Parameters = new ParameterRequest[]
                {
                    new ParameterRequest()
                    {
                        ParameterName = "TaxID",
                        Value = objParametro.TaxID
                    },
                    new ParameterRequest()
                    {
                        ParameterName = "CountryCode",
                        Value = objParametro.CountryCode
                    }
                };

                var response = ExigoService.GetCustomReportAsync(getRequest);

                bool ReportData = Convert.ToBoolean(response.GetCustomReportResult.ReportData.Nodes[1].Value);

                return Task.FromResult(ReportData);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  Task<bool> IsEmailAvailable(ValidateEmailRequestEntity objParametro)
        {
            try
            {
                GetCustomersRequest getRequest = new GetCustomersRequest();

                getRequest.Email = objParametro.Email;
                getRequest.CustomerStatuses = new int[]
                {
                    1
                };

                var a = ExigoService.GetCustomersAsync(getRequest);

                return Task.FromResult(a.GetCustomersResult.Customers.Length > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> GetCustomerTax(CustomerTaxRequestEntity objParametro)
        {
            try
            {
                GetCustomersRequest getRequest = new GetCustomersRequest();

                getRequest.TaxID = objParametro.TaxID;

                var a = ExigoService.GetCustomersAsync(getRequest);

                if (a.GetCustomersResult.Customers.Length > 0)
                {
                    return Task.FromResult(a.GetCustomersResult.Customers[0].CustomerType);
                }

                return Task.FromResult(-1);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<CustomerCreateEntity> CreateCustomer(CustomerCreateRequestEntity objParametros)
        {
            try
            {
                CreateCustomerRequest CreateCustomerRequest = new CreateCustomerRequest();

                CreateCustomerRequest.FirstName = objParametros.FirstName;
                CreateCustomerRequest.MiddleName = objParametros.MiddleName;
                CreateCustomerRequest.LastName = objParametros.LastName;
                CreateCustomerRequest.Email = objParametros.Email;
                CreateCustomerRequest.MainCountry = objParametros.MainCountry;

                CreateCustomerRequest.CanLogin = objParametros.CanLogin;
                CreateCustomerRequest.LoginName = objParametros.LoginName;
                CreateCustomerRequest.LoginPassword = objParametros.LoginPassword;
                CreateCustomerRequest.CustomerType = objParametros.CustomerType;
                CreateCustomerRequest.CustomerStatus = objParametros.CustomerStatus;

                CreateCustomerRequest.InsertEnrollerTree = objParametros.InsertEnrollerTree;
                CreateCustomerRequest.EnrollerID = objParametros.EnrollerID;

                CreateCustomerRequest.EntryDate = DateTime.Now;
                CreateCustomerRequest.DefaultWarehouseID = objParametros.DefaultWarehouseID;
                CreateCustomerRequest.CurrencyCode = objParametros.CurrencyCode;
                CreateCustomerRequest.LanguageID = objParametros.LanguageID;

                var a = ExigoService.CreateCustomerAsync(CreateCustomerRequest);

                CustomerCreateEntity objResponse = new CustomerCreateEntity()
                {
                    CustomerID = a.CreateCustomerResult.CustomerID
                };


                return Task.FromResult(objResponse); // (ExigoApiSoap)a.GetAdminWhitelistResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<CustomerExtendedEntity>> GetCustomerExtended(CustomerExtendedRequestEntity objParametros)
        {
            //return CustomerExigoService.GetCustomerExtended(objParametros);
            IEnumerable<CustomerExtendedEntity> objResponse = null;

            try
            {
                GetCustomerExtendedRequest getRequest = new GetCustomerExtendedRequest();

                getRequest.CustomerID = objParametros.CustomerID;
                getRequest.ExtendedGroupID = objParametros.GroupID;
                getRequest.CustomerExtendedID = objParametros.DetailID;

                var a = ExigoService.GetCustomerExtendedAsync(getRequest);

                var prueba = a.GetCustomerExtendedResult.Items;

                objResponse = a.GetCustomerExtendedResult.Items.Select(g => new CustomerExtendedEntity()
                {
                    CustomerID = g.CustomerID,
                    Field1 = g.Field1
                });

                return Task.FromResult(objResponse);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> UpdateCustomer(UpdateCustomerRequestEntity objParametros)
        {
            try
            {
                UpdateCustomerRequest getRequest = new UpdateCustomerRequest();

                getRequest.CustomerID = objParametros.CustomerID;
                if(objParametros.CustomerTypeID != null) getRequest.CustomerType = objParametros.CustomerTypeID;
                if (!string.IsNullOrEmpty(objParametros.LoginPassword)) getRequest.LoginPassword = objParametros.LoginPassword;

                var a = ExigoService.UpdateCustomer(getRequest);

                var prueba = a.UpdateCustomerResult.Result;                

                return Task.FromResult(true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> CreateCustomerExtended(CreateCustomerExtendedRequestEntity objParametros)
        {
            try
            {
                CreateCustomerExtendedRequest CreateCustomerRequest = new CreateCustomerExtendedRequest();

                CreateCustomerRequest.CustomerID = objParametros.CustomerID;
                CreateCustomerRequest.ExtendedGroupID = objParametros.ExtendedGroupID;

                var a = ExigoService.CreateCustomerExtendedAsync(CreateCustomerRequest);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
