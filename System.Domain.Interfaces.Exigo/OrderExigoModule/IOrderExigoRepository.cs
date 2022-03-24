using System.Domain.Entities.Exigo;
using System.Domain.Entities.Exigo.OrderExigoModule;
using System.Threading.Tasks;

namespace System.Domain.Interfaces.Exigo
{
    public interface IOrderExigoRepository
    {
        Task<TransactionalResponseEntity> ProcessTransaction(TransactionalRequestEntity objParametros);
        Task<bool> UpdateOrder(UpdateOrderRequestEntity objParametros);
        Task<OrderResponseEntity> GetOrder(GetOrderRequestEntity objParametros);
        Task<bool> CreatePayment(CreatePaymentRequestEntity objParametros);
    }
}
