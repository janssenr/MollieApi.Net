using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class PaymentEndpoint : CollectionEndpointAbstract<Payment, PaymentCollection>
    {
        const string RESOURCE_ID_PREFIX = "tr_";

        public PaymentEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("payments");
        }

        /// <summary>
        /// Creates a payment in Mollie.
        /// </summary>
        /// <param name="data">A Payment object containing details of the payment.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> Create(Payment data, Dictionary<string, string> filters = null)
        {
            return await RestCreate(data, filters);
        }

        /// <summary>
        /// Updates a payment in Mollie.
        /// </summary>
        /// <param name="data">A Payment object containing details on the payment.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Payment> Update(Payment data, Dictionary<string, string> filters = null)
        {
            return await RestUpdate(data, filters);
        }

        /// <summary>
        /// Retrieve a single payment from Mollie.
        /// 
        /// Will throw a ApiException if the payment id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Payment> Get(string paymentId, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(paymentId) || paymentId.IndexOf(RESOURCE_ID_PREFIX) == -1)
                throw new ApiException($"Invalid payment ID: '{paymentId}'. A payment ID should start with '{RESOURCE_ID_PREFIX}'.");

            return await RestRead(paymentId, parameters);
        }

        /// <summary>
        /// Deletes the given Payment.
        /// 
        /// Will throw a ApiException if the payment id is invalid or the resource cannot be found.
        /// Returns with HTTP status No Content (204) if successful.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public async Task<Payment> Delete(string paymentId)
        {
            return await RestDelete(paymentId);
        }

        /// <summary>
        /// Cancel the given Payment. This is just an alias of the 'Delete' method.
        /// 
        /// Will throw a ApiException if the payment id is invalid or the resource cannot be found.
        /// Returns with HTTP status No Content (204) if successful.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public async Task<Payment> Cancel(string paymentId)
        {
            return await RestDelete(paymentId);
        }

        /// <summary>
        /// Retrieves a collection of Payments from Mollie.
        /// </summary>
        /// <param name="from">The first payment ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PaymentCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
