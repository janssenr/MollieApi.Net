using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class CustomerPaymentsEndpoint : CollectionEndpointAbstract<Payment, PaymentCollection>
    {
        public CustomerPaymentsEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("customers_payments");
        }

        /// <summary>
        /// Create a payment for a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> CreateFor(Customer customer, Payment payment, Dictionary<string, string> filters = null)
        {
            return await CreateForId(customer.Id, payment, filters);
        }

        /// <summary>
        /// Create a payment for a Customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> CreateForId(string customerId, Payment payment, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestCreate(payment, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PaymentCollection> ListFor(Customer customer, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(customer.Id, from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PaymentCollection> ListForId(string customerId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(customerId);

            return await RestList(from, limit, parameters);
        }
    }
}
