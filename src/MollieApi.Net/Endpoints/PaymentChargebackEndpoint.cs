using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class PaymentChargebackEndpoint : CollectionEndpointAbstract<Chargeback, ChargebackCollection>
    {
        public PaymentChargebackEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("payments_chargebacks");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="chargebackId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Chargeback> GetFor(Payment payment, string chargebackId, Dictionary<string, string> filters = null)
        {
            return await GetForId(payment.Id, chargebackId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="chargebackId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Chargeback> GetForId(string paymentId, string chargebackId, Dictionary<string, string> filters = null)
        {
            SetParentId(paymentId);

            return await RestRead(chargebackId, filters);
        }

        /// <summary>
        /// Return all chargebacks for the Payment provided.
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ChargebackCollection> ListFor(Payment payment, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(payment.Id, from, limit, parameters);
        }

        /// <summary>
        /// Return all chargebacks for the provided Payment id.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ChargebackCollection> ListForId(string paymentId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(paymentId);

            return await RestList(from, limit, parameters);
        }
    }
}
