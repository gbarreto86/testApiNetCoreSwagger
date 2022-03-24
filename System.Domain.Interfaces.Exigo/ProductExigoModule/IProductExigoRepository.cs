using System;
using System.Collections.Generic;
using System.Domain.Entities.Exigo;
using System.Text;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.Exigo
{
    public interface IProductExigoRepository
    {
        Task<OrderCalculationResponseEntity> GetCalculateOrder(CalculateOrderRequestEntity objParametros);
    }
}
