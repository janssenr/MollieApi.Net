using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class PermissionEndpoint : CollectionEndpointAbstract<Permission, PermissionCollection>
    {
        public PermissionEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("permissions");
        }

        /// <summary>
        /// Retrieve a single Permission from Mollie.
        /// 
        /// Will throw a ApiException if the permission id is invalid.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Permission> Get(string permissionId, Dictionary<string, string> parameters = null)
        {
            return await RestRead(permissionId, parameters);
        }

        /// <summary>
        /// Retrieve all permissions.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<PermissionCollection> All(Dictionary<string, string> parameters = null)
        {
            return await RestList(null, null, parameters);
        }
    }
}
