using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class MethodEndpoint : CollectionEndpointAbstract<Method, MethodCollection>
    {
        public MethodEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("methods");
        }

        /// <summary>
        /// Retrieve all active methods. In test mode, this includes pending methods. The results are not paginated.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Obsolete("Use AllActive() instead")]
        public async Task<MethodCollection> All(Dictionary<string, string> parameters = null)
        {
            return await AllActive(parameters);
        }

        /// <summary>
        /// Retrieve all active methods for the organization. In test mode, this includes pending methods.
        /// The results are not paginated.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<MethodCollection> AllActive(Dictionary<string, string> parameters = null)
        {
            return await RestList(null, null, parameters);
        }

        /// <summary>
        /// Retrieve all available methods for the organization, including activated and not yet activated methods. The results are not paginated. Make sure to include the profileId parameter if using an OAuth Access Token.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<MethodCollection> AllAvailable(Dictionary<string, string> parameters = null)
        {
            string url = "methods/all" + BuildQueryString(parameters);

            return await _client.PerformHttpCall<MethodCollection>("GET", url);
        }

        /// <summary>
        /// Retrieve a payment method from Mollie.
        /// </summary>
        /// <param name="methodId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Method> Get(string methodId, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(methodId))
                throw new ApiException("Method ID is empty.");

            return await RestRead(methodId, parameters);
        }
    }
}
