using ExigoWebService;

namespace System.Persitence.Service.Exigo.Services
{
    public class ExigoService
    {
        private static ApiAuthentication _Authentication = ConnectionExigo.GetApiAuthentication();
        #region Login
        public static AuthenticateCustomerResponse1 AuthenticateCustomerAsync(AuthenticateCustomerRequest authenticateCustomerRequest)
        {
                return ConnectionExigo.ExigoApi().AuthenticateCustomerAsync(_Authentication, authenticateCustomerRequest).Result;
        }
        public static GetCustomersResponse1 GetCustomersAsync(GetCustomersRequest getCustomersRequest)
        {
            return ConnectionExigo.ExigoApi().GetCustomersAsync(_Authentication, getCustomersRequest).Result;
        }
        public static GetCustomerSiteResponse1 GetCustomerSiteAsync(GetCustomerSiteRequest getCustomer)
        {
            return ConnectionExigo.ExigoApi().GetCustomerSiteAsync(_Authentication,getCustomer).Result;
        }
        public static GetAutoOrdersResponse1 GetAutoOrdersAsync(GetAutoOrdersRequest getCustomer)
        {
            return ConnectionExigo.ExigoApi().GetAutoOrdersAsync(_Authentication, getCustomer).Result;
        }
        #endregion

        public static GetCustomReportResponse1 GetCustomReportAsync(GetCustomReportRequest getRequest)
        {
            return ConnectionExigo.ExigoApi().GetCustomReportAsync(_Authentication,getRequest).Result;
        }
        public static CreateCustomerResponse1 CreateCustomerAsync(CreateCustomerRequest CreateCustomerRequest)
        {
            return ConnectionExigo.ExigoApi().CreateCustomerAsync(_Authentication, CreateCustomerRequest).Result;
        }
        public static GetCustomerExtendedResponse1 GetCustomerExtendedAsync(GetCustomerExtendedRequest getRequest)
        {
            return ConnectionExigo.ExigoApi().GetCustomerExtendedAsync(_Authentication, getRequest).Result;
        }
        public static CreateCustomerExtendedResponse1 CreateCustomerExtendedAsync(CreateCustomerExtendedRequest CreateCustomerRequest)
        {
           return ConnectionExigo.ExigoApi().CreateCustomerExtendedAsync(_Authentication, CreateCustomerRequest).Result;
        }

        public static UpdateCustomerResponse1 UpdateCustomer(UpdateCustomerRequest updateCustomerRequest)
        {
            return ConnectionExigo.ExigoApi().UpdateCustomerAsync(_Authentication, updateCustomerRequest).Result;
        }

        #region Products

        public static CalculateOrderResponse1 CalculateOrderAsync(CalculateOrderRequest getCalculateOrderRequest)
        {
            return ConnectionExigo.ExigoApi().CalculateOrderAsync(_Authentication, getCalculateOrderRequest).Result;
        }

        #endregion
        #region ProcessTransaction
        public static ProcessTransactionResponse ProcessTransactionAsync(TransactionalRequest transactionRequest)
        {
            return ConnectionExigo.ExigoApi().ProcessTransactionAsync(_Authentication,transactionRequest).Result;
        }
        #endregion

        #region Order
        public static UpdateOrderResponse1 UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            return ConnectionExigo.ExigoApi().UpdateOrderAsync(_Authentication, updateOrderRequest).Result;
        }
        public static GetOrdersResponse1 GetOrders(GetOrdersRequest getOrderRequest)
        {
            return ConnectionExigo.ExigoApi().GetOrdersAsync(_Authentication, getOrderRequest).Result;
        }
        public static CreatePaymentResponse1 CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            return ConnectionExigo.ExigoApi().CreatePaymentAsync(_Authentication, createPaymentRequest).Result;
        }

        #endregion

    }
}
