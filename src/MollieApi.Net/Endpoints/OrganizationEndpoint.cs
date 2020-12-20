using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrganizationEndpoint : CollectionEndpointAbstract<Organization, OrganizationCollection>
    {
        public OrganizationEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("organizations");
        }

        /// <summary>
        /// Retrieve an organization from Mollie.
        /// 
        /// Will throw a ApiException if the organization id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Organization> Get(string organizationId, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(organizationId))
                throw new ApiException("Organization ID is empty.");

            return await RestRead(organizationId, parameters);
        }

        public async Task<Organization> Current(Dictionary<string, string> parameters = null)
        {
            return await RestRead("me", parameters);
        }
    }
}
