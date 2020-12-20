using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class ProfileMethodEndpoint : CollectionEndpointAbstract<Method, MethodCollection>
    {
        public ProfileMethodEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("profiles_methods");
        }

        /// <summary>
        /// Enable a method for the provided Profile object.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="method"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Method> CreateFor(Profile profile, Method method, Dictionary<string, string> filters = null)
        {
            return await CreateForId(profile.Id, method, filters);
        }

        /// <summary>
        /// Enable a method for the provided Profile ID.
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="method"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Method> CreateForId(string profileId, Method method, Dictionary<string, string> filters = null)
        {
            SetParentId(profileId);

            return await RestCreate(method, filters);
        }

        /// <summary>
        /// Enable a method for the current profile.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Method> CreateForCurrentProfile(Method method, Dictionary<string, string> filters = null)
        {
            return await CreateForId("me", method, filters);
        }

        /// <summary>
        /// Disable a method for the provided Profile object.
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="methodId"></param>
        /// <returns></returns>
        public async Task<Method> DeleteFor(Profile profile, string methodId)
        {
            return await DeleteForId(profile.Id, methodId);
        }

        /// <summary>
        /// Disable a method for the provided Profile ID.
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="methodId"></param>
        /// <returns></returns>
        public async Task<Method> DeleteForId(string profileId, string methodId)
        {
            SetParentId(profileId);

            return await RestDelete(methodId);
        }

        /// <summary>
        /// Disable a method for the current profile.
        /// </summary>
        /// <param name="methodId"></param>
        /// <returns></returns>
        public async Task<Method> DeleteForCurrentProfile(string methodId)
        {
            return await DeleteForId("me", methodId);
        }
    }
}
