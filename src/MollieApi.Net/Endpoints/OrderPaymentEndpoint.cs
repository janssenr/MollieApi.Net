using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrderPaymentEndpoint : CollectionEndpointAbstract<Payment, PaymentCollection>
    {
        public OrderPaymentEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("orders_payments");
        }

        /// <summary>
        /// Creates a payment in Mollie for a specific order.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> CreateFor(Order order, Payment payment, Dictionary<string, string> filters = null)
        {
            return await CreateForId(order.Id, payment, filters);
        }

        /// <summary>
        /// Creates a payment in Mollie for a specific order ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> CreateForId(string orderId, Payment payment, Dictionary<string, string> filters = null)
        {
            SetParentId(orderId);

            return await RestCreate(payment, filters);
        }
    }
}
