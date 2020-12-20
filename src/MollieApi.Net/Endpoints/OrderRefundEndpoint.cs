using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrderRefundEndpoint : CollectionEndpointAbstract<Refund, RefundCollection>
    {
        public OrderRefundEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("orders_refunds");
        }

        /// <summary>
        /// Refund some order lines. You can provide an empty array for the "lines" data to refund all eligible lines for this order.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="refund"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> CreateFor(Order order, Refund refund, Dictionary<string, string> filters = null)
        {
            return await CreateForId(order.Id, refund, filters);
        }

        /// <summary>
        /// Refund some order lines. You can provide an empty array for the "lines" data to refund all eligible lines for this order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="refund"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> CreateForId(string orderId, Refund refund, Dictionary<string, string> filters = null)
        {
            SetParentId(orderId);

            return await RestCreate(refund, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<RefundCollection> ListFor(Order order, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(order.Id, from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<RefundCollection> ListForId(string orderId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(orderId);

            return await RestList(from, limit, parameters);
        }
    }
}
