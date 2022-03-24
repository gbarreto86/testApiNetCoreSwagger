using System;
using System.Collections.Generic;
using System.Domain.Entities.Exigo;
using System.Domain.Entities.Exigo.CustomerExigoModule;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.Exigo
{
    public interface ICustomerExigoRepository
    {
        Task<AuthenticateEntity> AuthenticateCustomer(AuthenticateRequestEntity objParametro);

        Task<CustomerExigoEntity> GetCustomer(CustomerExigoRequestEntity objParametro);

        Task<string> GetCustomerWebAlias(CustomerExigoRequestEntity objParametro);

        Task<bool> GetValidateAutoOrder(ValidateAutoOrderRequestEntity objParametro);

        Task<bool> IsTaxIDAvailable(CustomerTaxAvailableRequestEntity objParametro);

        Task<bool> IsEmailAvailable(ValidateEmailRequestEntity objParametro);

        Task<int> GetCustomerTax(CustomerTaxRequestEntity objParametro);

        Task<CustomerCreateEntity> CreateCustomer(CustomerCreateRequestEntity objParametros);

        Task<IEnumerable<CustomerExtendedEntity>> GetCustomerExtended(CustomerExtendedRequestEntity objParametros);

        Task<bool> CreateCustomerExtended(CreateCustomerExtendedRequestEntity objParametros);

        public Task<bool> UpdateCustomer(UpdateCustomerRequestEntity objParametros);

    }
}
