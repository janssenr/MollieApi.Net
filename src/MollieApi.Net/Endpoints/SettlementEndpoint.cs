using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class SettlementEndpoint : CollectionEndpointAbstract<Settlement, SettlementCollection>
    {
        public SettlementEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("settlements");
        }

        /// <summary>
        /// Retrieve a single settlement from Mollie.
        /// 
        /// Will throw a ApiException if the settlement id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="settlementId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Settlement> Get(string settlementId, Dictionary<string, string> parameters = null)
        {
            return await RestRead(settlementId, parameters);
        }

        /// <summary>
        /// Retrieve the details of the current settlement that has not yet been paid out.
        /// </summary>
        /// <returns></returns>
        public async Task<Settlement> Next()
        {
            return await RestRead("next", null);
        }

        /// <summary>
        /// Retrieve the details of the open balance of the organization.
        /// </summary>
        /// <returns></returns>
        public async Task<Settlement> Open()
        {
            return await RestRead("open", null);
        }

        /// <summary>
        /// Retrieves a collection of Settlements from Mollie.
        /// </summary>
        /// <param name="from">The first settlement ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<SettlementCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
