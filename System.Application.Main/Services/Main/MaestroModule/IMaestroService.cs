using System;
using System.Application.Main.Dtos.Main.MaestroModule;
using System.Collections.Generic;
using System.Domain.Entities.MaestroModule;
using System.Text;
using System.Threading.Tasks;

namespace System.Application.Main.Services.MaestroModule
{
    public interface IMaestroService
    {
        Task<IEnumerable<OutCustomerDto>> GetCustomer();
        Task<IEnumerable<OutCustomerDto>> GetCustomerByID(CustomerByIdDto objParametros);
        Task<IEnumerable<OutMessageDto>> NewCustomer(NewCustomerDto objParametros);

    }
}
