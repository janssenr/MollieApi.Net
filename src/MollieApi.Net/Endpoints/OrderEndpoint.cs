using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrderEndpoint : CollectionEndpointAbstract<Order, OrderCollection>
    {
        const string RESOURCE_ID_PREFIX = "ord_";

        public OrderEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("orders");
        }

        /// <summary>
        /// Creates a order in Mollie.
        /// </summary>
        /// <param name="data">A Order object containing details of the order.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Order> Create(Order data, Dictionary<string, string> filters = null)
        {
            return await RestCreate(data, filters);
        }

        /// <summary>
        /// Saves the order's updated billingAddress and/or shippingAddress.
        /// </summary>
        /// <param name="data">A Order object containing details of the order.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Order> Update(Order data, Dictionary<string, string> filters = null)
        {
            return await RestUpdate(data, filters);
        }

        /// <summary>
        /// Retrieve a single order from Mollie.
        /// 
        /// Will throw a ApiException if the order id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Order> Get(string orderId, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(orderId) || orderId.IndexOf(RESOURCE_ID_PREFIX) == -1)
                throw new ApiException($"Invalid order ID: '{orderId}'. A order ID should start with '{RESOURCE_ID_PREFIX}'.");

            return await RestRead(orderId, parameters);
        }

        /// <summary>
        /// Cancel the given Order.
        /// 
        /// If the order was partially shipped, the status will be "completed" instead of "canceled".
        /// Will throw a ApiException if the order id is invalid or the resource cannot be found.
        /// Returns the canceled order with HTTP status 200.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<Order> Cancel(string orderId)
        {
            return await RestDelete(orderId);
        }

        /// <summary>
        /// Retrieves a collection of Orders from Mollie.
        /// </summary>
        /// <param name="from">The first order ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<OrderCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
