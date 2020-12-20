using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class ChargebackEndpoint : CollectionEndpointAbstract<Chargeback, ChargebackCollection>
    {
        public ChargebackEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("chargebacks");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargebackId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Chargeback> Get(string chargebackId, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(chargebackId))
                throw new ApiException("ChargebackId ID is empty.");

            return await RestRead(chargebackId, parameters);
        }

        /// <summary>
        /// Retrieves a collection of Captures from Mollie.
        /// </summary>
        /// <param name="from">The first chargeback ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ChargebackCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
