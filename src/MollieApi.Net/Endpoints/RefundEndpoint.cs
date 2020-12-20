using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class RefundEndpoint : CollectionEndpointAbstract<Refund, RefundCollection>
    {
        public RefundEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("refunds");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refundId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Refund> Get(string refundId, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(refundId))
                throw new ApiException("Refund ID is empty.");

            return await RestRead(refundId, parameters);
        }

        /// <summary>
        /// Retrieves a collection of Refunds from Mollie.
        /// </summary>
        /// <param name="from">The first refund ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<RefundCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
