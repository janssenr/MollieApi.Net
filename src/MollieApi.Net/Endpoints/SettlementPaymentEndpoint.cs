using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class SettlementPaymentEndpoint : CollectionEndpointAbstract<Payment, PaymentCollection>
    {
        public SettlementPaymentEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("settlements_payments");
        }

        /// <summary>
        /// Retrieves a collection of Payments from Mollie.
        /// </summary>
        /// <param name="settlement"></param>
        /// <param name="from">The first payment ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PaymentCollection> PageFor(Settlement settlement, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await PageForId(settlement.Id, from, limit, parameters);
        }

        /// <summary>
        /// Retrieves a collection of Payments from Mollie.
        /// </summary>
        /// <param name="settlementId"></param>
        /// <param name="from">The first payment ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PaymentCollection> PageForId(string settlementId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(settlementId);

            return await RestList(from, limit, parameters);
        }
    }
}
