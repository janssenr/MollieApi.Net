using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OnboardingEndpoint : EndpointAbstract<Onboarding, BaseCollection<Onboarding>>
    {
        public OnboardingEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("onboarding/me");
        }

        /// <summary>
        /// Submit data that will be prefilled in the merchant’s onboarding.
        /// Please note that the data you submit will only be processed when the onboarding status is needs-data.
        /// 
        /// Information that the merchant has entered in their dashboard will not be overwritten.
        /// 
        /// Will throw a ApiException if the resource cannot be found.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<Onboarding> Submit(Onboarding data, Dictionary<string, string> filters = null)
        {
            return await _client.PerformHttpCall<Onboarding>(MollieApiClient.HTTP_POST, GetResourcePath() + BuildQueryString(filters), ParseRequestBody(data));
        }

        /// <summary>
        /// Retrieve the organization's onboarding status from Mollie.
        /// 
        /// Will throw a ApiException if the resource cannot be found.
        /// </summary>
        /// <returns></returns>
        public async Task<Onboarding> Get(Dictionary<string, string> filters = null)
        {
            return await _client.PerformHttpCall<Onboarding>(MollieApiClient.HTTP_GET, GetResourcePath() + BuildQueryString(filters));
        }
    }
}
