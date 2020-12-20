using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class ProfileEndpoint : CollectionEndpointAbstract<Profile, ProfileCollection>
    {
        public ProfileEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("profiles");
        }

        /// <summary>
        /// Creates a Profile in Mollie.
        /// </summary>
        /// <param name="data">A Profile object containing details of the profile.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Profile> Create(Profile data, Dictionary<string, string> filters = null)
        {
            return await RestCreate(data, filters);
        }

        /// <summary>
        /// Updates a profile in Mollie.
        /// </summary>
        /// <param name="data">A Profile object containing details on the profile.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Profile> Update(Profile data, Dictionary<string, string> filters = null)
        {
            return await RestUpdate(data, filters);
        }
        /// <summary>
        /// Retrieve a Profile from Mollie.
        /// 
        /// Will throw a ApiException if the profile id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Profile> Get(string profileId, Dictionary<string, string> parameters = null)
        {
            if (profileId == "me")
                return await GetCurrent(parameters);

            return await RestRead(profileId, parameters);
        }

        /// <summary>
        /// Retrieve a Profile from Mollie.
        /// 
        /// Will throw a ApiException if the profile id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Profile> GetCurrent(Dictionary<string, string> parameters = null)
        {
            return await RestRead("me", parameters);
        }

        /// <summary>
        /// Delete a Profile from Mollie.
        /// 
        /// Will throw a ApiException if the profile id is invalid or the resource cannot be found.
        /// Returns with HTTP status No Content (204) if successful.
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        public async Task<Profile> Delete(string profileId)
        {
            return await RestDelete(profileId);
        }

        /// <summary>
        /// Retrieves a collection of Profiles from Mollie.
        /// </summary>
        /// <param name="from">The first profile ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ProfileCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
