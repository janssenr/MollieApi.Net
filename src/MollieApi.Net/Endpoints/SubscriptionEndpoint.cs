using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class SubscriptionEndpoint : CollectionEndpointAbstract<Subscription, SubscriptionCollection>
    {
        public SubscriptionEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("subscriptions");
        }

        /// <summary>
        /// Retrieves a collection of Subscriptions from Mollie.
        /// </summary>
        /// <param name="from">The first subscription ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<SubscriptionCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
