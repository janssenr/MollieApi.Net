using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class PaymentCaptureEndpoint : CollectionEndpointAbstract<Capture, CaptureCollection>
    {
        public PaymentCaptureEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("payments_captures");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="captureId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Capture> GetFor(Payment payment, string captureId, Dictionary<string, string> filters = null)
        {
            return await GetForId(payment.Id, captureId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="captureId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Capture> GetForId(string paymentId, string captureId, Dictionary<string, string> filters = null)
        {
            SetParentId(paymentId);

            return await RestRead(captureId, filters);
        }

        /// <summary>
        /// Return all captures for the Payment provided.
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<CaptureCollection> ListFor(Payment payment, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(payment.Id, from, limit, parameters);
        }

        /// <summary>
        /// Return all captures for the provided Payment id.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<CaptureCollection> ListForId(string paymentId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(paymentId);

            return await RestList(from, limit, parameters);
        }
    }
}
