using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrderLineEndpoint : CollectionEndpointAbstract<OrderLine, OrderLineCollection>
    {
        public OrderLineEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("orders_lines");
        }

        public async Task<OrderLine> Update(OrderLine data, Dictionary<string, string> filters = null)
        {
            SetParentId(data.OrderId);

            return await RestUpdate(data, filters);
        }

        /// <summary>
        /// Cancel lines for the provided order.
        /// The data array must contain a lines array.
        /// Returns null if successful.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<OrderLineCollection> CancelFor(Order order, OrderLineCollection data)
        {
            return await CancelForId(order.Id, data);
        }

        /// <summary>
        /// Cancel lines for the provided order id.
        /// The data array must contain a lines array.
        /// Returns null if successful.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<OrderLineCollection> CancelForId(string orderId, OrderLineCollection data)
        {
            SetParentId(orderId);

            return await _client.PerformHttpCall<OrderLineCollection>(MollieApiClient.HTTP_DELETE, GetResourcePath(), ParseRequestBody(data));

            //return null;
        }
    }
}
