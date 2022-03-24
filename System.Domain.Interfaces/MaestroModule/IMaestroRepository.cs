using System;
using System.Collections.Generic;
using System.Domain.Entities.MaestroModule;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.MaestroModule
{
    public interface IMaestroRepository
    {
        Task<IEnumerable<CustomerEntity>> GetCustomer();
        Task<IEnumerable<CustomerIdEntity>> GetCustomerByID(CustomerIdRequestEntity objParametros);
        Task<IEnumerable<MessageEntity>> NewCustomer(NewCustomerRequestEntity objParametros);
    }
}
