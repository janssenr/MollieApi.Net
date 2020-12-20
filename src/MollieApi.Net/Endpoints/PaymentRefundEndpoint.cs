using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class PaymentRefundEndpoint : CollectionEndpointAbstract<Refund, RefundCollection>
    {
        public PaymentRefundEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("payments_refunds");
        }

        /// <summary>
        /// Issue a refund for the provided Payment object.
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="refund"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> CreateFor(Payment payment, Refund refund, Dictionary<string, string> filters = null)
        {
            return await CreateForId(payment.Id, refund, filters);
        }

        /// <summary>
        /// Issue a refund for the provided Payment ID.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="refund"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> CreateForId(string paymentId, Refund refund, Dictionary<string, string> filters = null)
        {
            SetParentId(paymentId);

            return await RestCreate(refund, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="refundId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> GetFor(Payment payment, string refundId, Dictionary<string, string> filters = null)
        {
            return await GetForId(payment.Id, refundId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="refundId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Refund> GetForId(string paymentId, string refundId, Dictionary<string, string> filters = null)
        {
            SetParentId(paymentId);

            return await RestRead(refundId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<RefundCollection> ListFor(Payment payment, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(payment.Id, from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<RefundCollection> ListForId(string paymentId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(paymentId);

            return await RestList(from, limit, parameters);
        }
    }
}
